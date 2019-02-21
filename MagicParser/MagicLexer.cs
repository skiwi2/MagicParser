using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MagicParser.Tokens;

namespace MagicParser
{
    public class MagicLexer
    {
        private readonly IDictionary<string, PunctuationToken> punctuationTokenMap;

        private readonly IDictionary<string, IToken> textTokenMap;

        public MagicLexer()
        {
            punctuationTokenMap = PunctuationToken.All.ToDictionary(token => token.Text);
            textTokenMap = GetTextTokens().ToDictionary(token => token.Text);
        }

        private static IList<IToken> GetTextTokens()
        {
            var textTokens = new List<IToken>();
            textTokens.AddRange(ActionToken.All);
            textTokens.AddRange(ContinuousEffectToken.All);
            textTokens.AddRange(KeywordToken.All);
            textTokens.AddRange(PhaseToken.All);
            textTokens.AddRange(PlayerToken.All);
            textTokens.AddRange(ResourceToken.All);
            textTokens.AddRange(SubtypeToken.All);
            textTokens.AddRange(Token.All);
            textTokens.AddRange(TriggeredAbilityToken.All);
            textTokens.AddRange(TypeToken.All);
            textTokens.AddRange(ZoneToken.All);
            return textTokens;
        }

        public IEnumerable<IToken> CreateTokens(string cardName, string text)
        {
            var localTextTokenMap = new Dictionary<string, IToken>(textTokenMap);
            if (localTextTokenMap.ContainsKey(cardName))
            {
                throw new LexerException($"Could not add {cardName} to localTextTokenMap as it already exists");
            }
            else
            {
                localTextTokenMap[cardName] = new ThisToken(cardName);
            }

            var tokens = new List<IToken>();

            var modifierBuilder = new StringBuilder();
            var textBuilder = new StringBuilder();
            var digitBuilder = new StringBuilder();

            bool TryFinishBuilders(char ch)
            {
                if (modifierBuilder.Length > 0)
                {
                    tokens.Add(new ModifierToken(modifierBuilder.ToString()));
                    modifierBuilder.Clear();
                    return true;
                }
                else if (textBuilder.Length > 0)
                {
                    if (localTextTokenMap.TryGetValue(textBuilder.ToString(), out var textToken))
                    {
                        tokens.Add(textToken);
                        textBuilder.Clear();
                        return true;
                    }
                    else
                    {
                        if (ch == ' ')
                        {
                            textBuilder.Append(ch);
                            return false;
                        }
                        else
                        {
                            throw new LexerException($"Could not find '{textBuilder.ToString()}' in localTextTokenMap and next character is {ch}, which is not a space");
                        }
                    }
                }
                else if (digitBuilder.Length > 0)
                {
                    tokens.Add(new NumberToken(digitBuilder.ToString()));
                    digitBuilder.Clear();
                    return true;
                }
                return true;
            }

            int pos = 0;
            var charEnumerator = text.GetEnumerator();
            while (charEnumerator.MoveNext())
            {
                var ch = charEnumerator.Current;
                switch (ch)
                {
                    case ' ':
                    case ',':
                    case '.':
                    case '/':
                        {
                            if (TryFinishBuilders(ch))
                            {
                                if (punctuationTokenMap.TryGetValue(ch.ToString(), out var punctuationToken))
                                {
                                    tokens.Add(punctuationToken);
                                }
                                else
                                {
                                    throw new LexerException($"Could not find punctuation token '{ch}' in punctuationTokenMap");
                                }
                            }
                            break;
                        }
                    case '\\':
                        {
                            if (!TryFinishBuilders(ch))
                            {
                                throw new LexerException($"Expected to finish the builders, but failed to do so, current character is '{ch}' at position {pos}");
                            }
                            pos++;
                            if (charEnumerator.MoveNext() && charEnumerator.Current == 'n')
                            {
                                tokens.Add(PunctuationToken.NewLine);
                            }
                            else
                            {
                                throw new LexerException($"Expected character 'n' at position {pos} in {text}, but it was not found");
                            }
                            break;
                        }
                    case '+':
                    case '-':
                        if (modifierBuilder.Length == 0)
                        {
                            modifierBuilder.Append(ch);
                        }
                        else
                        {
                            throw new LexerException($"Unexpected character '{ch}' at position {pos}, modifierBuilder already is {modifierBuilder.ToString()}");
                        }
                        break;
                    case var letter when char.IsLetter(ch):
                        textBuilder.Append(ch);
                        break;
                    case var digit when char.IsDigit(ch):
                        if (modifierBuilder.Length > 0)
                        {
                            modifierBuilder.Append(ch);
                        }
                        else
                        {
                            digitBuilder.Append(ch);
                        }
                        break;
                    default:
                        throw new LexerException($"Unrecognized character '{ch}' at position {pos} in text {text}");
                }
                pos++;
            }
            
            if (modifierBuilder.Length > 0)
            {
                throw new LexerException($"Unused modifier token '{modifierBuilder.ToString()}' after all text has been lexed");
            }
            if (textBuilder.Length > 0)
            {
                throw new LexerException($"Unused text token '{textBuilder.ToString()}' after all text has been lexed");
            }
            if (digitBuilder.Length > 0)
            {
                throw new LexerException($"Unused digit token '{digitBuilder.ToString()}' after all text has been lexed");
            }

            return tokens;
        }
    }
}
