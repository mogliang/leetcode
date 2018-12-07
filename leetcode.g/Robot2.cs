using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode.g
{
    public class RobotCleanRoom2
    {
        HashSet<string> _dict;
        public void CleanRoom(Robot robot)
        {
            _dict = new HashSet<string>();
            CleanRommImpl(robot, 0, 0);
        }

        void CleanRommImpl(Robot robot, int x, int y)
        {
            var key = x + "," + y;
            if (_dict.Contains(key))
            {
                return;
            }
            robot.Clean();
            _dict.Add(key);

            if (MoveUp(robot))
            {
                CleanRommImpl(robot, x - 1, y);
                MoveDown(robot);
            }
            if(MoveRight(robot))
            {
                CleanRommImpl(robot, x, y + 1);
                MoveLeft(robot);
            }
            if (MoveDown(robot))
            {
                CleanRommImpl(robot, x + 1, y);
                MoveUp(robot);
            }
            if (MoveLeft(robot))
            {
                CleanRommImpl(robot, x, y - 1);
                MoveRight(robot);
            }
        }

        bool MoveUp(Robot robot)
        {
            return robot.Move();
        }

        bool MoveRight(Robot robot)
        {
            robot.TurnRight();
            var res = robot.Move();
            robot.TurnLeft();
            return res;
        }

        bool MoveLeft(Robot robot)
        {
            robot.TurnLeft();
            var res = robot.Move();
            robot.TurnRight();
            return res;
        }

        bool MoveDown(Robot robot)
        {
            robot.TurnLeft();
            robot.TurnLeft();
            var res = robot.Move();
            robot.TurnRight();
            robot.TurnRight();
            return res;
        }
    }

    public interface Robot
    {
        // Returns true if the cell in front is open and robot moves into the cell.
        // Returns false if the cell in front is blocked and robot stays in the current cell.
        bool Move();

        // Robot will stay in the same cell after calling turnLeft/turnRight.
        // Each turn will be 90 degrees.
        void TurnLeft();
        void TurnRight();

        // Clean the current cell.
        void Clean();
    }
}
