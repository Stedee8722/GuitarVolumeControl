using GDWeave.Godot;
using GDWeave.Godot.Variants;
using GDWeave.Modding;

namespace GuitarVolumeControl.Scripts
{
    internal class UserSaveScript : IScriptMod
    {
        public IEnumerable<Token> Modify(string path, IEnumerable<Token> tokens)
        {
            // "music_vol": 1.0,
            var musicVolWaiter = new MultiTokenWaiter([
                t => t is ConstantToken {Value: StringVariant {Value: "music_vol"}},
                t => t.Type is TokenType.Colon,
                t => t is ConstantToken {Value: RealVariant {Value: 1}},
                t => t.Type is TokenType.Comma,
                t => t.Type is TokenType.Newline && t.AssociatedData == 2
            ], allowPartialMatch: true);

            foreach (var token in tokens)
            {
                if (musicVolWaiter.Check(token))
                {
                    yield return token;

                    // "gtr_vol": 1.0,
                    yield return new ConstantToken(new StringVariant("gtr_vol"));
                    yield return new Token(TokenType.Colon);
                    yield return new ConstantToken(new RealVariant(1));
                    yield return new Token(TokenType.Comma);
                    yield return new Token(TokenType.Newline, 2);

                    // "radio_vol": 1.0,
                    yield return new ConstantToken(new StringVariant("radio_vol"));
                    yield return new Token(TokenType.Colon);
                    yield return new ConstantToken(new RealVariant(1));
                    yield return new Token(TokenType.Comma);

                    yield return token;
                }
                else
                {
                    yield return token;
                }
            }
        }

        public bool ShouldRun(string path) => path == "res://Scenes/Singletons/UserSave/usersave.gdc";
    }
}
