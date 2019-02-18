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
            textTokens.AddRange(KeywordToken.All);
            textTokens.AddRange(PlayerToken.All);
            textTokens.AddRange(ResourceToken.All);
            textTokens.AddRange(SubtypeToken.All);
            textTokens.AddRange(Token.All);
            textTokens.AddRange(TriggeredAbilityToken.All);
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

            var textBuilder = new StringBuilder();
            var digitBuilder = new StringBuilder();

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
                    case '\\':
                        if (textBuilder.Length > 0)
                        {
                            if (localTextTokenMap.TryGetValue(textBuilder.ToString(), out var textToken))
                            {
                                tokens.Add(textToken);
                                textBuilder.Clear();
                            }
                            else
                            {
                                if (ch == ' ')
                                {
                                    textBuilder.Append(ch);
                                }
                                else
                                {
                                    throw new LexerException($"Could not find {textBuilder.ToString()} in localTextTokenMap and next character is {ch}, which is not a space");
                                }
                                break;
                            }
                        }
                        else if (digitBuilder.Length > 0)
                        {
                            tokens.Add(new NumberToken(digitBuilder.ToString()));
                            digitBuilder.Clear();
                        }

                        if (ch == '\\')
                        {
                            pos++;
                            if (charEnumerator.MoveNext() && charEnumerator.Current == 'n')
                            {
                                tokens.Add(PunctuationToken.NewLine);
                            }
                            else
                            {
                                throw new LexerException($"Expected character n at position {pos} in {text}, but it was not found");
                            }
                        }
                        else
                        {
                            if (punctuationTokenMap.TryGetValue(ch.ToString(), out var punctuationToken))
                            {
                                tokens.Add(punctuationToken);
                            }
                            else
                            {
                                throw new LexerException($"Could not find punctuation token {ch.ToString()} in punctuationTokenMap");
                            }
                        }
                        break;
                    case var letter when char.IsLetter(ch):
                        textBuilder.Append(ch);
                        break;
                    case var digit when char.IsDigit(ch):
                        digitBuilder.Append(digit);
                        break;
                    default:
                        throw new LexerException($"Unrecognized character {ch} at position {pos} in text {text}");
                }
                pos++;
            }

            if (textBuilder.Length > 0)
            {
                throw new LexerException($"Unused text token {textBuilder.ToString()} after all text has been lexed");
            }

            if (digitBuilder.Length > 0)
            {
                throw new LexerException($"Unused digit token {digitBuilder.ToString()} after all text has been lexed");
            }

            return tokens;
        }
    }
}
