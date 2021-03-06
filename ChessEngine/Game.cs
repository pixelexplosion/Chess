using System;
using System.Collections.Generic;

namespace ChessEngine
{
    public class Game
    {
        public void GameLoop()
        {
            UI ui = new UI();
            Board board = new Board();
            ui.printBoard(board.Board1, new List<Coordinate>(), board.IsCheck, board.IsMate);

            while (true)
            {
                Instruction iNstruction = ui.inputHandler();

                if (iNstruction.getType() == InstructionType.getMove)
                {
                    ui.printBoard(board.Board1,
                        board.getPossibleMoves(((GetMoveInstruction) iNstruction).position), board.IsCheck, board.IsMate);
                }
                else
                {
                    Move move = ((MoveInstruction) iNstruction).Move;
                    board.move(move);
                    ui.printBoard(board.Board1, new List<Coordinate>(), board.IsCheck, board.IsMate);
                }

                if (board.IsMate)
                {
                    break;
                }
            }

            Console.ReadKey();

        }
    }
}