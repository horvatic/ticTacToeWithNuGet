﻿module ScreenEdit
open TicTacToe.Core.GameSettings
open IInputOutPut
open TicTacToe.Core.ITicTacToeBoxClass

let invertedScreen(board : ITicTacToeBox)
                  (message : int)
                  (io : IInputOut) : unit =
    if board.cellCount() = 9 then
            let package = 
                [
                "-------------------------------------------------";
                "|\t"+ board.getGlyphAtLocation(2)+"\t|\t"+ board.getGlyphAtLocation(1)+"\t|\t"+ board.getGlyphAtLocation(0)+"\t|";
                "-------------------------------------------------";
                "|\t"+ board.getGlyphAtLocation(5)+"\t|\t"+ board.getGlyphAtLocation(4)+"\t|\t"+ board.getGlyphAtLocation(3)+"\t|";
                "-------------------------------------------------";
                "|\t"+ board.getGlyphAtLocation(8)+"\t|\t"+ board.getGlyphAtLocation(7)+"\t|\t"+ board.getGlyphAtLocation(6)+"\t|";
                "-------------------------------------------------";
                ]
            io.cleanScreen()
            io.printNoScreenFlush([message;])
            io.printNoScreenFlushNoTranslate(package)
    else
        let package = 
            [
             "-----------------------------------------------------------------";
             "|\t"+ board.getGlyphAtLocation(3)+"\t|\t"+ board.getGlyphAtLocation(2)+"\t|\t"+ board.getGlyphAtLocation(1)+"\t|\t"+ board.getGlyphAtLocation(0)+"\t|";
             "-----------------------------------------------------------------";
             "|\t"+ board.getGlyphAtLocation(7)+"\t|\t"+ board.getGlyphAtLocation(6)+"\t|\t"+ board.getGlyphAtLocation(5)+"\t|\t"+ board.getGlyphAtLocation(4)+"\t|";
             "-----------------------------------------------------------------";
             "|\t"+ board.getGlyphAtLocation(11)+"\t|\t"+ board.getGlyphAtLocation(10)+"\t|\t"+ board.getGlyphAtLocation(9)+"\t|\t"+ board.getGlyphAtLocation(8)+"\t|";
             "-----------------------------------------------------------------";
             "|\t"+ board.getGlyphAtLocation(15)+"\t|\t"+ board.getGlyphAtLocation(14)+"\t|\t"+ board.getGlyphAtLocation(13)+"\t|\t"+ board.getGlyphAtLocation(12)+"\t|";
             "-----------------------------------------------------------------";
            ]
        io.cleanScreen()
        io.printNoScreenFlush([message;])
        io.printNoScreenFlushNoTranslate(package)

let nonInvertedScreen(board : ITicTacToeBox)
                     (message : int)
                     (io : IInputOut) : unit =
    if board.cellCount() = 9 then
        let package = 
            [
            "-------------------------------------------------";
            "|\t"+ board.getGlyphAtLocation(0)+"\t|\t"+ board.getGlyphAtLocation(1)+"\t|\t"+ board.getGlyphAtLocation(2)+"\t|";
            "-------------------------------------------------";
            "|\t"+ board.getGlyphAtLocation(3)+"\t|\t"+ board.getGlyphAtLocation(4)+"\t|\t"+ board.getGlyphAtLocation(5)+"\t|";
            "-------------------------------------------------";
            "|\t"+ board.getGlyphAtLocation(6)+"\t|\t"+ board.getGlyphAtLocation(7)+"\t|\t"+ board.getGlyphAtLocation(8)+"\t|";
            "-------------------------------------------------";
            ]
        io.cleanScreen()
        io.printNoScreenFlush([message;])
        io.printNoScreenFlushNoTranslate(package)

    else
        let package = 
            [
             "-----------------------------------------------------------------";
             "|\t"+ board.getGlyphAtLocation(0)+"\t|\t"+ board.getGlyphAtLocation(1)+"\t|\t"+ board.getGlyphAtLocation(2)+"\t|\t"+ board.getGlyphAtLocation(3)+"\t|";
             "-----------------------------------------------------------------";
             "|\t"+ board.getGlyphAtLocation(4)+"\t|\t"+ board.getGlyphAtLocation(5)+"\t|\t"+ board.getGlyphAtLocation(6)+"\t|\t"+ board.getGlyphAtLocation(7)+"\t|";
             "-----------------------------------------------------------------";
             "|\t"+ board.getGlyphAtLocation(8)+"\t|\t"+ board.getGlyphAtLocation(9)+"\t|\t"+ board.getGlyphAtLocation(10)+"\t|\t"+ board.getGlyphAtLocation(11)+"\t|";
             "-----------------------------------------------------------------";
             "|\t"+ board.getGlyphAtLocation(12)+"\t|\t"+ board.getGlyphAtLocation(13)+"\t|\t"+ board.getGlyphAtLocation(14)+"\t|\t"+ board.getGlyphAtLocation(15)+"\t|";
             "-----------------------------------------------------------------";
            ]
        io.cleanScreen()
        io.printNoScreenFlush([message;])
        io.printNoScreenFlushNoTranslate(package)

let writeToScreen(board : ITicTacToeBox)
                 (inverted : bool )(message : int )
                 (io : IInputOut) : unit =
    if not inverted then
        nonInvertedScreen(board)(message)(io)
    else
        invertedScreen(board)(message)(io)