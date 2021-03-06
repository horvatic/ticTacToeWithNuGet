﻿module BuildAndStartGameTest
open Xunit
open FsUnit
open BuildAndStartGame
open TicTacToe.Core.userInputException
open InputOutPutTestBuildGame
open TicTacToe.Core.PlayerValues
open System.Collections.Generic
open TicTacToe.Core.Translate

[<Fact>]
let Run_Whole_Game_Once_Huamn_Vs_Human() =
    let io = new InputOutTestBuildGameManyOps(new Queue<string>(["4";"n";"y";"y";"w";"e";"y";"y";
                                                                 "1";"5";"2";"6";"3";"7";"4";"n";
                                                                 ])) 
    Assert.Equal(0, buildAndStartGame io)

[<Fact>]
let Run_Whole_Game_Once_AI_AI() =
    let io = new InputOutTestBuildGameManyOps(new Queue<string>(["3";"y";"w";"e";"n";"y";"n;"])) 
    Assert.Equal(0, buildAndStartGame io)

[<Fact>]
let Run_Whole_Game_Once_Take_Twice_Correct_Settings() =
    let io = new InputOutTestBuildGameManyOps(new Queue<string>(["3";"n";"n";"y";"w";"e";"n";"n";
                                                                 "3";"n";"n";"y";"w";"e";"n";"y";
                                                                 "1";"2";"9";"n";
                                                                 ])) 
    Assert.Equal(0, buildAndStartGame io)


[<Fact>]
let Run_Whole_Game_Twice_Diifent_Settings() =
    let io = new InputOutTestBuildGameManyOps(new Queue<string>(["3";"n";"n";"y";"w";"e";"n";"y";
                                                                 "1";"2";"9";"y";"n";"3";"n";"n";
                                                                 "n";"t";"o";"y";"y";"3";"6";"n"])) 
    Assert.Equal(0, buildAndStartGame io)

[<Theory>]
[<InlineData("y")>]
[<InlineData("Y")>]
[<InlineData("s")>]
[<InlineData("S")>]
let Run_Whole_Game_Twice_Same_Settings_Y(option : string) =
    let io = new InputOutTestBuildGameManyOps(new Queue<string>(["3";"n";"n";"y";"t";"y";
                                                                 "n";"y";"1";"2";"9";option;
                                                                 option;"1";"2";"9";"n";])) 
    Assert.Equal(0, buildAndStartGame io)

[<Fact>]
let Run_Whole_Game() =
    let io = new InputOutTestBuildGameManyOps(new Queue<string>(["3";"n";"n";"y";"e";"r";"n";"y";"1";"2";"9";"n";"n";])) 
    Assert.Equal(0, buildAndStartGame io)

[<Fact>]
let User_Does_Not_Want_AI_VS_AI() =
     
    let io = new InputOutTestBuildGameManyOps(new Queue<string>(["N";]))

    Assert.Equal(false, aiVsAi io Blank)

[<Fact>]
let User_Does_Want_AI_VS_AI() = 
    let io = new InputOutTestBuildGameManyOps(new Queue<string>(["Y";]))
    Assert.Equal(true, aiVsAi io Blank)

[<Fact>]
let User_Want_AI_VS_AI_Bad_Take_Three_Tries() = 
    let io = new InputOutTestBuildGameManyOps(new Queue<string>(["X"; "X"; "Y";]))
    Assert.Equal(true, aiVsAi io Blank)

[<Fact>]
let User_Does_Not_AI_VS_AI_Bad_Take_Three_Tries() = 
    let io = new InputOutTestBuildGameManyOps(new Queue<string>(["X"; "X"; "N";]))
    Assert.Equal(false, aiVsAi io Blank)

[<Fact>]
let User_Does_Not_Want_To_Go_First() = 
    let io = new InputOutTestBuildGameManyOps(new Queue<string>(["N";]))

    Assert.Equal(int playerVals.AI, whoGoingFirst io Blank false)

[<Fact>]
let User_Does_Want_To_Go_First() = 
    let io = new InputOutTestBuildGameManyOps(new Queue<string>(["Y";]))  
    Assert.Equal(int playerVals.Human, whoGoingFirst io Blank false)

[<Fact>]
let User_Want_Human_Vs_Human_Bad_Take_Three_Tries() = 
    let io = new InputOutTestBuildGameManyOps(new Queue<string>(["X"; "X"; "Y";])) 
    Assert.Equal(true, isHuamnVSHuman io Blank false)

[<Fact>]
let User_Does_Not_Human_Vs_Human_Bad_Take_Three_Tries() = 
    let io = new InputOutTestBuildGameManyOps(new Queue<string>(["X"; "X"; "N";])) 
    Assert.Equal(false, isHuamnVSHuman io Blank false)

[<Fact>]
let User_Selected_AI_vs_AI_Human_Skip_Human_Vs_Human() = 
    let io = new InputOutTestBuildGameManyOps(new Queue<string>(["";])) 
    Assert.Equal(false, isHuamnVSHuman io Blank true)

[<Fact>]
let User_Selected_AI_vs_AI_Human_Skip_Who_Goes_First() = 
    let io = new InputOutTestBuildGameManyOps(new Queue<string>(["";])) 
    Assert.Equal(int playerVals.AI, whoGoingFirst  io Blank true)

[<Fact>]
let User_Want_To_Go_First_Bad_Take_Three_Tries() = 
    let io = new InputOutTestBuildGameManyOps(new Queue<string>(["X"; "X"; "Y";])) 
    Assert.Equal(int playerVals.Human, whoGoingFirst io Blank false)

[<Fact>]
let User_Want_To_Go_Second_Bad_Take_Three_Tries() = 
    let io = new InputOutTestBuildGameManyOps(new Queue<string>(["X"; "X"; "N";])) 
    Assert.Equal(int playerVals.AI, whoGoingFirst io Blank false)

[<Fact>]
let User_Setting_Bad() = 
    let io = new InputOutTestBuildGameManyOps(new Queue<string>(["N";])) 
    let aIplayerValue = int playerVals.AI
    Assert.Equal(false, settingGood io 3 false aIplayerValue "X" "#" false Blank false)

[<Fact>]
let User_Setting_Good() = 
    let io = new InputOutTestBuildGameManyOps(new Queue<string>(["Y";])) 
    let aIplayerValue = int playerVals.AI
    Assert.Equal(true, settingGood io 3 false aIplayerValue "X" "#" false Blank false)

[<Fact>]
let User_Setting_Bad_Take_Three_Tries() = 
    let io = new InputOutTestBuildGameManyOps(new Queue<string>(["X"; "X"; "N";])) 

    let aIplayerValue = int playerVals.AI
    Assert.Equal(false, settingGood io 3 false aIplayerValue "X" "#" false Blank false)

[<Fact>]
let User_Setting_Good_Take_Three_Tries() = 
    let io = new InputOutTestBuildGameManyOps(new Queue<string>(["X"; "X"; "Y";])) 
    let aIplayerValue = int playerVals.AI
    Assert.Equal(true, settingGood io 3 false aIplayerValue "X" "#" false Blank false)

[<Fact>]
let User_Picks_AI_Glyph_unsucsfully_Until_No_Pick_Players() = 
    let io = new InputOutTestBuildGameManyOps(new Queue<string>(["X"; "X"; "@";])) 
    let aIGlyph = "@"
    Assert.Equal(aIGlyph, getaIGlyph io Blank "X")

[<Fact>]
let User_Picks_AI_Glyph_unsucsfully_Until_FithPick() = 
    let io = new InputOutTestBuildGameManyOps(new Queue<string>(["33"; "222"; "3m"; "3m"; "3"])) 
    let aIGlyph = "3"
    Assert.Equal(aIGlyph, getaIGlyph io Blank "X")

[<Fact>]
let User_Picks_AI_Glyph_Sucsfully() = 
    let io = new InputOutTestBuildGame("3")
    let aIGlyph = "3"
    Assert.Equal(aIGlyph, getaIGlyph io Blank "X")

[<Fact>]
let User_Picks_Player_Glyph_unsucsfully_Until_FithPick() = 
    let io = new InputOutTestBuildGameManyOps(new Queue<string>(["33"; "222"; "3m"; "3m"; "3"])) 
    let userGlyph = "3"
    Assert.Equal(userGlyph, getplayerGlyph io Blank false)

[<Fact>]
let User_Picks_Player_Glyph_Sucsfully() = 
    let io = new InputOutTestBuildGame("3")
    let userGlyph = "3"
    Assert.Equal(userGlyph, getplayerGlyph io Blank false)

[<Fact>]
let User_Picks_4X4_Three_Tries_Box() = 
    let io = new InputOutTestBuildGameManyOps(new Queue<string>(["dfef"; "dwq"; "4"])) 
    Assert.Equal(4, getBoxOfUserSize io Blank)

[<Fact>]
let User_Picks_3X3_Three_Tries_Box() =
    let io = new InputOutTestBuildGameManyOps(new Queue<string>(["dfef"; "dwq"; "3"])) 
    Assert.Equal(3, getBoxOfUserSize io Blank)

[<Fact>]
let User_Picks_4X4_Box() = 
    let io = new InputOutTestBuildGame("4")
    Assert.Equal(4, getBoxOfUserSize io Blank)

[<Fact>]
let User_Picks_3X3_Box() = 
    let io = new InputOutTestBuildGame("3")
    Assert.Equal(3, getBoxOfUserSize io Blank)

[<Fact>]
let Set_Game_Is_Inverted() =
    let io = new InputOutTestBuildGame("y")
    Assert.Equal(true, isGameInverted io Blank)

[<Fact>]
let Set_Game_Is_Not_Inverted() =
    let io = new InputOutTestBuildGame("n")
    Assert.Equal(false, isGameInverted io Blank)

[<Fact>]
let Set_Game_Is_Takes_Two_Tries_Non_Inverted() =
    let io = new InputOutTestBuildGameManyOps(new Queue<string>(["wqeqw"; "n"])) 
    Assert.Equal(false, isGameInverted io Blank)

[<Fact>]
let Set_Game_Is_Not_Takes_Two_Tries_Inverted() =
    let io = new InputOutTestBuildGameManyOps(new Queue<string>(["wqeqw"; "y"])) 
    Assert.Equal(true, isGameInverted io Blank)

[<Fact>]
let Make_Tic_Tac_Toe_Box_3X3_Correct() =
    Assert.Equal(3, getTicTacToeBoxSize 3)

[<Fact>]
let Make_Tic_Tac_Toe_Box_4X4_Correct() =
    Assert.Equal(4, getTicTacToeBoxSize 4)

[<Fact>]   // test
let Make_Tic_Tac_Toe_Box_5X5_Correct_To_Exception() =
    Assert.Throws<OutOfBoundsOverFlow>((fun () -> getTicTacToeBoxSize 5 |> ignore))
//    (fun () -> getTicTacToeBoxSize 5 |> ignore) |> should throw typeof<OutOfBoundsOverFlow>

[<Fact>]   // test
let Make_Tic_Tac_Toe_Box_0X0_Correct_To_Exception() =
    Assert.Throws<OutOfBoundsUnderFlow>((fun () -> getTicTacToeBoxSize 0 |> ignore))
//    (fun () -> getTicTacToeBoxSize 0 |> ignore) |> should throw typeof<OutOfBoundsUnderFlow>

[<Fact>]   // test
let User_Input_Number_To_Large_For_Tic_tac_Toe_To_Exception() =
    let io = new InputOutTestBuildGameManyOps(new Queue<string>(["5"; "3";])) 
    Assert.Equal(3, getBoxOfUserSize io Blank)

[<Fact>]   // test
let User_Input_Number_To_Small_For_Tic_tac_Toe_To_Exception() =
    let io = new InputOutTestBuildGameManyOps(new Queue<string>(["0"; "3"])) 
    Assert.Equal(3, getBoxOfUserSize io Blank)