using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MagicParser.Nodes;
using MagicParser.Tokens;

namespace MagicParser
{
    public class MagicParser
    {
        public INode Parse(IEnumerable<IToken> tokens)
        {
            var enumerator = tokens.GetEnumerator();
            var root = Parse(enumerator);
            if (enumerator.MoveNext())
            {
                throw new ParserException($"Not all tokens have been consumed, next token is {enumerator.Current}");
            }
            return root;
        }

        private INode Parse(IEnumerator<IToken> enumerator)
        {
            var stack = new Stack<INode>();
            while (enumerator.MoveNext())
            {
                switch (enumerator.Current)
                {
                    case PunctuationToken punctuationToken when (punctuationToken == PunctuationToken.NewLine):
                        {
                            var left = stack.Pop();
                            var right = ParseUpTillToken(enumerator, PunctuationToken.NewLine, false);
                            stack.Push(new MultilineNode(left, right));
                            break;
                        }
                    case PunctuationToken punctuationToken when (punctuationToken == PunctuationToken.Space):
                        {
                            break;
                        }
                    case TriggeredAbilityToken triggeredAbilityToken:
                        {
                            var when = ParseUpTillToken(enumerator, PunctuationToken.Comma, true);
                            var then = ParseUpTillToken(enumerator, PunctuationToken.Dot, true);
                            stack.Push(new TriggeredAbilityNode(when, then));
                            break;
                        }
                    case ActionToken actionToken:
                        {
                            var left = stack.Pop();
                            var right = ParseUpTillEnd(enumerator);
                            stack.Push(new ActionNode(actionToken, left, right));
                            break;
                        }
                    case Token token when (token == Token.ForEach):
                        {
                            var action = stack.Pop();
                            var condition = ParseUpTillEnd(enumerator);
                            stack.Push(new ForEachNode(action, condition));
                            break;
                        }
                    case Token token when (token == Token.Control):
                        {
                            var owner = stack.Pop();
                            var objects = stack.Pop();
                            stack.Push(new ControlsNode(objects, owner));
                            break;
                        }
                    case ResourceToken resourceToken:
                        {
                            var number = stack.Pop();
                            stack.Push(new ResourceNode(resourceToken, number));
                            break;
                        }
                    case KeywordToken keywordToken:
                    case NumberToken numberToken:
                    case PlayerToken playerToken:
                    case SubtypeToken subtypeToken:
                    case ThisToken thisToken:
                    case ZoneToken zoneToken:
                        {
                            stack.Push(new ConstantNode<IToken>(enumerator.Current));
                            break;
                        }
                    default:
                        {
                            throw new ParserException($"Unexpeced node {enumerator.Current} encountered");
                        }
                }
            }
            if (stack.Count == 1)
            {
                return stack.Pop();
            }
            else
            {
                throw new ParserException($"Expected stack to have a length of one, but stack is [{string.Join(", ", stack)}]");
            }
        }

        private INode ParseUpTillToken(IEnumerator<IToken> enumerator, IToken targetToken, bool matchMandatory)
        {
            return Parse(GetTokensUpTillToken(enumerator, token => token == targetToken, matchMandatory).GetEnumerator());
        }

        private INode ParseUpTillTokenWithType(IEnumerator<IToken> enumerator, Type targetTokenType, bool matchMandatory)
        {
            return Parse(GetTokensUpTillToken(enumerator, token => token.GetType() == targetTokenType, matchMandatory).GetEnumerator());
        }

        private INode ParseUpTillEnd(IEnumerator<IToken> enumerator)
        {
            return Parse(GetTokensUpTillToken(enumerator, token => false, false).GetEnumerator());
        }

        private IList<IToken> GetTokensUpTillToken(IEnumerator<IToken> enumerator, Predicate<IToken> targetTokenPredicate, bool matchMandatory)
        {
            var tokens = new List<IToken>();
            while (enumerator.MoveNext())
            {
                if (targetTokenPredicate(enumerator.Current))
                {
                    return tokens;
                }
                tokens.Add(enumerator.Current);
            }
            if (matchMandatory)
            {
                throw new ParserException($"Failed to find target token matching predicate {targetTokenPredicate}");
            }
            else
            {
                return tokens;
            }
        }
    }
}
