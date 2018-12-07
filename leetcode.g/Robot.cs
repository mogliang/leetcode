//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace leetcode.g
//{
//    public class RobotCleanRoom
//    {
//        Dictionary<int, Dictionary<int, bool>> _dict;
//        public void CleanRoom(Robot robot)
//        {
//            _dict = new Dictionary<int, Dictionary<int, bool>>();
//            CleanRommImpl(robot, 0, 0, Direction.Right);
//        }

//        void CleanRommImpl(Robot robot, int x, int y, Direction direction)
//        {
//            robot.Clean();
//            MarkClean(x, y);

//            GetForwardPos(x, y, direction, out int x1, out int y1);
//            if (!Cleaned(x1, y1))
//            {
//                // >
//                robot.Move();
//                CleanRommImpl(robot, x1, y1, direction);
                
//                // <
//                robot.TurnRight();
//                robot.TurnRight();
//                robot.Move();
//                direction = (Direction)((int)(direction + 2) % 4);
//            }

//            GetRightPos(x, y, direction, out int x2, out int y2);
//            if (!Cleaned(x2, y2))
//            {
//                // ^
//                robot.TurnRight();
//                direction= (Direction)((int)(direction + 1) % 4);
//                CleanRommImpl(robot, x2, y2, direction);
//            }
//            // v
//            direction = (Direction)((int)(direction + 2) % 4);

//            // v
//            GetForwardPos(x, y, direction, out int x3, out int y3);
//            if (!Cleaned(x3, y3))
//            {
//                CleanRommImpl(robot, x3, y3, direction);
//            }
//            // ^
//            direction = (Direction)((int)(direction + 2) % 4);

//            // <
//            robot.TurnLeft();
//            direction = (Direction)((int)(direction + 3) % 4);
//        }

//        void GetForwardPos(int x, int y, Direction direction, out int x1, out int y1)
//        {
//            switch (direction)
//            {
//                case Direction.Up:
//                    x1 = x - 1;
//                    y1 = y;
//                    break;
//                case Direction.Right:
//                    x1 = x;
//                    y1 = y + 1;
//                    break;
//                case Direction.Down:
//                    x1 = x + 1;
//                    y1 = y;
//                    break;
//                case Direction.Left:
//                    x1 = x;
//                    y1 = y - 1;
//                    break;
//                default:
//                    x1 = x;
//                    y1 = y;
//                    break;
//            }
//        }

//        void GetLeftPos(int x, int y, Direction direction, out int x1, out int y1)
//        {
//            GetForwardPos(x, y, (Direction)((int)(direction + 3) % 4), out x1, out y1);
//        }

//        void GetRightPos(int x, int y, Direction direction, out int x1, out int y1)
//        {
//            GetForwardPos(x, y, (Direction)((int)(direction + 1) % 4), out x1, out y1);
//        }

//        Direction Move(int x1, int y1, Direction direction, int x2, int y2)
//        {

//        }

//        bool Cleaned(int x, int y)
//        {
//            return _dict.ContainsKey(x) && _dict[x].ContainsKey(y);
//        }

//        void MarkClean(int x, int y)
//        {
//            if (!_dict.ContainsKey(x))
//                _dict[x] = new Dictionary<int, bool>();
//            _dict[x][y] = true;
//        }

//        Direction Reverse(Direction dir)
//        {
//            return (Direction)((int)(dir+2)%4);
//        }

//        public enum Direction
//        {
//            Up,
//            Right,
//            Down,
//            Left
//        }
//    }

//    public interface Robot
//    {
//        // Returns true if the cell in front is open and robot moves into the cell.
//        // Returns false if the cell in front is blocked and robot stays in the current cell.
//        bool Move();

//        // Robot will stay in the same cell after calling turnLeft/turnRight.
//        // Each turn will be 90 degrees.
//        void TurnLeft();
//        void TurnRight();

//        // Clean the current cell.
//        void Clean();
//    }
//}
