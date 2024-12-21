using GDWeave.Godot;
using GDWeave.Godot.Variants;
using GDWeave.Modding;

namespace GuitarVolumeControl.Scripts
{
    internal class OptionsMenuScript : IScriptMod
    {
        public IEnumerable<Token> Modify(string path, IEnumerable<Token> tokens)
        {
            // $"%music_vol".value = PlayerData.player_options.music_vol
            var stringEditWaiter = new MultiTokenWaiter([
                t => t.Type is TokenType.Dollar,
                t => t is ConstantToken {Value: StringVariant {Value: "%music_vol"}},
                t => t.Type is TokenType.Period,
                t => t is IdentifierToken {Name:"value"},
                t => t.Type is TokenType.OpAssign,
                t => t is IdentifierToken {Name:"PlayerData"},
                t => t.Type is TokenType.Period,
                t => t is IdentifierToken {Name:"player_options"},
                t => t.Type is TokenType.Period,
                t => t is IdentifierToken {Name:"music_vol"},
                t => t.Type is TokenType.Newline && t.AssociatedData == 1
            ]);

            // $"%music_vol".value = 1.0
            var resetWaiter = new MultiTokenWaiter([
                t => t.Type is TokenType.Dollar,
                t => t is ConstantToken {Value: StringVariant {Value: "%music_vol"}},
                t => t.Type is TokenType.Period,
                t => t is IdentifierToken {Name:"value"},
                t => t.Type is TokenType.OpAssign,
                t => t is ConstantToken {Value: RealVariant {Value: 1}},
                t => t.Type is TokenType.Newline && t.AssociatedData == 1
            ]);

            // PlayerData.player_options.music_vol = $"%music_vol".value
            var saveWaiter = new MultiTokenWaiter([
                t => t is IdentifierToken {Name:"PlayerData"},
                t => t.Type is TokenType.Period,
                t => t is IdentifierToken {Name:"player_options"},
                t => t.Type is TokenType.Period,
                t => t is IdentifierToken {Name:"music_vol"},
                t => t.Type is TokenType.OpAssign,
                t => t.Type is TokenType.Dollar,
                t => t is ConstantToken {Value: StringVariant {Value: "%music_vol"}},
                t => t.Type is TokenType.Period,
                t => t is IdentifierToken {Name:"value"},
                t => t.Type is TokenType.Newline && t.AssociatedData == 1
            ]);

            // AudioServer.set_bus_volume_db(index, linear2db(PlayerData.player_options.sfx_vol))
            var audioSetWaiter = new MultiTokenWaiter([
                t => t is IdentifierToken { Name: "AudioServer" },
                t => t.Type is TokenType.Period,
                t => t is IdentifierToken { Name: "set_bus_volume_db" },
                t => t.Type is TokenType.ParenthesisOpen,
                t => t is IdentifierToken { Name: "index" },
                t => t.Type is TokenType.Comma,
                t => t.Type is TokenType.BuiltInFunc && t.AssociatedData == (uint?)BuiltinFunction.MathLinear2Db,
                t => t.Type is TokenType.ParenthesisOpen,
                t => t is IdentifierToken { Name: "PlayerData" },
                t => t.Type is TokenType.Period,
                t => t is IdentifierToken { Name: "player_options" },
                t => t.Type is TokenType.Period,
                t => t is IdentifierToken { Name: "sfx_vol" },
                t => t.Type is TokenType.ParenthesisClose,
                t => t.Type is TokenType.ParenthesisClose,
                t => t.Type is TokenType.Newline && t.AssociatedData == 1
            ]);

            // func _on_music_vol_value_changed(value): $"%music_label".text = str(value * 100.0) + "%"
            var functionWaiter = new MultiTokenWaiter([
                t => t.Type is TokenType.PrFunction,
                t => t is IdentifierToken { Name: "_on_music_vol_value_changed" },
                t => t.Type is TokenType.ParenthesisOpen,
                t => t is IdentifierToken { Name: "value" },
                t => t.Type is TokenType.ParenthesisClose,
                t => t.Type is TokenType.Colon,
                t => t.Type is TokenType.Dollar,
                t => t is ConstantToken {Value: StringVariant {Value: "%music_label"}},
                t => t.Type is TokenType.Period,
                t => t is IdentifierToken { Name: "text" },
                t => t.Type is TokenType.OpAssign,
                t => t.Type is TokenType.BuiltInFunc && t.AssociatedData == (uint?)BuiltinFunction.TextStr,
                t => t.Type is TokenType.ParenthesisOpen,
                t => t is IdentifierToken { Name: "value" },
                t => t.Type is TokenType.OpMul,
                t => t is ConstantToken {Value: RealVariant {Value: 100}},
                t => t.Type is TokenType.ParenthesisClose,
                t => t.Type is TokenType.OpAdd,
                t => t is ConstantToken {Value: StringVariant {Value: "%"}},
                t => t.Type is TokenType.Newline
            ]);

            foreach (var token in tokens)
            {
                if (stringEditWaiter.Check(token))
                {
                    Console.WriteLine("1");
                    yield return token;

                    // if PlayerData.player_options.has("gtr_vol"):
                    yield return new Token(TokenType.CfIf);
                    yield return new IdentifierToken("PlayerData");
                    yield return new Token(TokenType.Period);
                    yield return new IdentifierToken("player_options");
                    yield return new Token(TokenType.Period);
                    yield return new IdentifierToken("has");
                    yield return new Token(TokenType.ParenthesisOpen);
                    yield return new ConstantToken(new StringVariant("gtr_vol"));
                    yield return new Token(TokenType.ParenthesisClose);
                    yield return new Token(TokenType.Colon);
                    yield return new Token(TokenType.Newline, 2);

                    // $"Control/Panel/tabs_main/main/ScrollContainer/HBoxContainer/VBoxContainer/gtr_vol/VBoxContainer/gtr_vol".value = PlayerData.player_options.gtr_vol
                    yield return new Token(TokenType.Dollar);
                    yield return new ConstantToken(new StringVariant("Control/Panel/tabs_main/main/ScrollContainer/HBoxContainer/VBoxContainer/gtr_vol/VBoxContainer/gtr_vol"));
                    yield return new Token(TokenType.Period);
                    yield return new IdentifierToken("value");
                    yield return new Token(TokenType.OpAssign);
                    yield return new IdentifierToken("PlayerData");
                    yield return new Token(TokenType.Period);
                    yield return new IdentifierToken("player_options");
                    yield return new Token(TokenType.Period);
                    yield return new IdentifierToken("gtr_vol");
                    yield return new Token(TokenType.Newline, 1);

                    // else:
                    yield return new Token(TokenType.CfElse);
                    yield return new Token(TokenType.Colon);
                    yield return new Token(TokenType.Newline, 2);

                    // $"Control/Panel/tabs_main/main/ScrollContainer/HBoxContainer/VBoxContainer/gtr_vol/VBoxContainer/gtr_vol".value = 1.0
                    yield return new Token(TokenType.Dollar);
                    yield return new ConstantToken(new StringVariant("Control/Panel/tabs_main/main/ScrollContainer/HBoxContainer/VBoxContainer/gtr_vol/VBoxContainer/gtr_vol"));
                    yield return new Token(TokenType.Period);
                    yield return new IdentifierToken("value");
                    yield return new Token(TokenType.OpAssign);
                    yield return new ConstantToken(new RealVariant(1));
                    yield return new Token(TokenType.Newline, 2);

                    // PlayerData.player_options["gtr_vol"] = 1.0
                    yield return new IdentifierToken("PlayerData");
                    yield return new Token(TokenType.Period);
                    yield return new IdentifierToken("player_options");
                    yield return new Token(TokenType.BracketOpen);
                    yield return new ConstantToken(new StringVariant("gtr_vol"));
                    yield return new Token(TokenType.BracketClose);
                    yield return new Token(TokenType.OpAssign);
                    yield return new ConstantToken(new RealVariant(1));

                    yield return token;
                }
                else if (resetWaiter.Check(token))
                {
                    Console.WriteLine("1");
                    yield return token;

                    // $"Control/Panel/tabs_main/main/ScrollContainer/HBoxContainer/VBoxContainer/gtr_vol/VBoxContainer/gtr_vol".value = 1.0
                    yield return new Token(TokenType.Dollar);
                    yield return new ConstantToken(new StringVariant("Control/Panel/tabs_main/main/ScrollContainer/HBoxContainer/VBoxContainer/gtr_vol/VBoxContainer/gtr_vol"));
                    yield return new Token(TokenType.Period);
                    yield return new IdentifierToken("value");
                    yield return new Token(TokenType.OpAssign);
                    yield return new ConstantToken(new RealVariant(1));

                    yield return token;
                }
                else if (saveWaiter.Check(token))
                {
                    Console.WriteLine("1");
                    yield return token;

                    // PlayerData.player_options.gtr_vol = $"Control/Panel/tabs_main/main/ScrollContainer/HBoxContainer/VBoxContainer/gtr_vol/VBoxContainer/gtr_vol".value
                    yield return new IdentifierToken("PlayerData");
                    yield return new Token(TokenType.Period);
                    yield return new IdentifierToken("player_options");
                    yield return new Token(TokenType.Period);
                    yield return new IdentifierToken("gtr_vol");
                    yield return new Token(TokenType.OpAssign);
                    yield return new Token(TokenType.Dollar);
                    yield return new ConstantToken(new StringVariant("Control/Panel/tabs_main/main/ScrollContainer/HBoxContainer/VBoxContainer/gtr_vol/VBoxContainer/gtr_vol"));
                    yield return new Token(TokenType.Period);
                    yield return new IdentifierToken("value");

                    yield return token;
                }
                else if (audioSetWaiter.Check(token))
                {
                    Console.WriteLine("1");
                    yield return token;

                    // index = AudioServer.get_bus_index("Guitar")
                    yield return new IdentifierToken("index");
                    yield return new Token(TokenType.OpAssign);
                    yield return new IdentifierToken("AudioServer");
                    yield return new Token(TokenType.Period);
                    yield return new IdentifierToken("get_bus_index");
                    yield return new Token(TokenType.ParenthesisOpen);
                    yield return new ConstantToken(new StringVariant("Guitar"));
                    yield return new Token(TokenType.ParenthesisClose);
                    yield return new Token(TokenType.Newline, 1);

                    // if PlayerData.player_options.has("gtr_vol"):
                    yield return new Token(TokenType.CfIf);
                    yield return new IdentifierToken("PlayerData");
                    yield return new Token(TokenType.Period);
                    yield return new IdentifierToken("player_options");
                    yield return new Token(TokenType.Period);
                    yield return new IdentifierToken("has");
                    yield return new Token(TokenType.ParenthesisOpen);
                    yield return new ConstantToken(new StringVariant("gtr_vol"));
                    yield return new Token(TokenType.ParenthesisClose);
                    yield return new Token(TokenType.Colon);
                    yield return new Token(TokenType.Newline, 2);

                    // AudioServer.set_bus_volume_db(index, linear2db(PlayerData.player_options.gtr_vol))
                    yield return new IdentifierToken("AudioServer");
                    yield return new Token(TokenType.Period);
                    yield return new IdentifierToken("set_bus_volume_db");
                    yield return new Token(TokenType.ParenthesisOpen);
                    yield return new IdentifierToken("index");
                    yield return new Token(TokenType.Comma);
                    yield return new Token(TokenType.BuiltInFunc, (uint?)BuiltinFunction.MathLinear2Db);
                    yield return new Token(TokenType.ParenthesisOpen);
                    yield return new IdentifierToken("PlayerData");
                    yield return new Token(TokenType.Period);
                    yield return new IdentifierToken("player_options");
                    yield return new Token(TokenType.Period);
                    yield return new IdentifierToken("gtr_vol");
                    yield return new Token(TokenType.ParenthesisClose);
                    yield return new Token(TokenType.ParenthesisClose);
                    yield return new Token(TokenType.Newline, 1);

                    // else:
                    yield return new Token(TokenType.CfElse);
                    yield return new Token(TokenType.Colon);
                    yield return new Token(TokenType.Newline, 2);

                    // AudioServer.set_bus_volume_db(index, linear2db(1.0))
                    yield return new IdentifierToken("AudioServer");
                    yield return new Token(TokenType.Period);
                    yield return new IdentifierToken("set_bus_volume_db");
                    yield return new Token(TokenType.ParenthesisOpen);
                    yield return new IdentifierToken("index");
                    yield return new Token(TokenType.Comma);
                    yield return new Token(TokenType.BuiltInFunc, (uint?)BuiltinFunction.MathLinear2Db);
                    yield return new Token(TokenType.ParenthesisOpen);
                    yield return new ConstantToken(new RealVariant(1));
                    yield return new Token(TokenType.ParenthesisClose);
                    yield return new Token(TokenType.ParenthesisClose);
                    yield return new Token(TokenType.Newline, 2);

                    // PlayerData.player_options["gtr_vol"] = 1.0
                    yield return new IdentifierToken("PlayerData");
                    yield return new Token(TokenType.Period);
                    yield return new IdentifierToken("player_options");
                    yield return new Token(TokenType.BracketOpen);
                    yield return new ConstantToken(new StringVariant("gtr_vol"));
                    yield return new Token(TokenType.BracketClose);
                    yield return new Token(TokenType.OpAssign);
                    yield return new ConstantToken(new RealVariant(1));
                    yield return new Token(TokenType.Newline, 1);

                    // AudioServer.set_bus_send(index, "FadeBus")
                    yield return new IdentifierToken("AudioServer");
                    yield return new Token(TokenType.Period);
                    yield return new IdentifierToken("set_bus_send");
                    yield return new Token(TokenType.ParenthesisOpen);
                    yield return new IdentifierToken("index");
                    yield return new Token(TokenType.Comma);
                    yield return new ConstantToken(new StringVariant("FadeBus"));
                    yield return new Token(TokenType.ParenthesisClose);

                    yield return token;
                } else if (functionWaiter.Check(token))
                {
                    Console.WriteLine("1");
                    yield return token;

                    // func _on_guitar_vol_value_changed(value): $"Control/Panel/tabs_main/main/ScrollContainer/HBoxContainer/VBoxContainer/gtr_vol/VBoxContainer/gtr_label".text = str(value * 100.0) + "%"
                    yield return new Token(TokenType.PrFunction);
                    yield return new IdentifierToken("_on_guitar_vol_value_changed");
                    yield return new Token(TokenType.ParenthesisOpen);
                    yield return new IdentifierToken("value");
                    yield return new Token(TokenType.ParenthesisClose);
                    yield return new Token(TokenType.Colon);
                    yield return new Token(TokenType.Dollar);
                    yield return new ConstantToken(new StringVariant("Control/Panel/tabs_main/main/ScrollContainer/HBoxContainer/VBoxContainer/gtr_vol/VBoxContainer/gtr_label"));
                    yield return new Token(TokenType.Period);
                    yield return new IdentifierToken("text");
                    yield return new Token(TokenType.OpAssign);
                    yield return new Token(TokenType.BuiltInFunc, (uint?)BuiltinFunction.TextStr);
                    yield return new Token(TokenType.ParenthesisOpen);
                    yield return new IdentifierToken("value");
                    yield return new Token(TokenType.OpMul);
                    yield return new ConstantToken(new RealVariant(100));
                    yield return new Token(TokenType.ParenthesisClose);
                    yield return new Token(TokenType.OpAdd);
                    yield return new ConstantToken(new StringVariant("%"));

                    yield return token;
                }
                else
                {
                    yield return token;
                }
            }
        }

        public bool ShouldRun(string path) => path == "res://Scenes/Singletons/OptionsMenu/options_menu.gdc";
    }
}
