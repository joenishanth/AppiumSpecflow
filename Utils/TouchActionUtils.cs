using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;
using System.Drawing;

namespace AppiumSpecflow.Utils
{
    public class Coordinates
    {
        public double X_Axis { get; set; }
        public double Y_Axis { get; set; }
    }
    public enum Direction
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }
    public enum StartPoint
    {
        MIDDLE,
        TOP_MIDDLE,
        TOP_RIGHT,
        TOP_LEFT,
        BOTTOM_MIDDLE,
        BOTTOM_RIGHT,
        BOTTOM_LEFT
    }
    public class TouchActionUtils
    {
        private readonly AppiumDriver<IWebElement> _driver;
        public TouchActionUtils(AppiumDriver<IWebElement> driver)
        {
            _driver = driver;
        }
        public void SwipeScreen(Direction direction, StartPoint startPoint = StartPoint.MIDDLE, double scrollPercent = 100)
        {
            Size screensize = _driver.Manage().Window.Size;
            var startCoOrdinates = GetStartTouchCoOrdinates(screensize, startPoint);
            var endCoordinates = GetEndTouchCoOrdinates(screensize, direction, startCoOrdinates, scrollPercent);

            new TouchAction((IPerformsTouchActions)_driver)
                .Press(startCoOrdinates.X_Axis, startCoOrdinates.Y_Axis)
                .Wait(1000)
                .MoveTo(endCoordinates.X_Axis, endCoordinates.Y_Axis)
                .Release()
                .Perform();
        }
        private static Coordinates GetStartTouchCoOrdinates(Size screensize, StartPoint startPoint)
        {
            var screenOffSet = 10;
            var startCoordinates = new Coordinates()
            {
                X_Axis = screensize.Width / 2,
                Y_Axis = screensize.Height / 2
            };
            switch (startPoint)
            {
                case StartPoint.MIDDLE:
                    break;
                case StartPoint.TOP_MIDDLE:
                    startCoordinates.Y_Axis = screenOffSet;
                    break;
                case StartPoint.TOP_RIGHT:
                    startCoordinates.X_Axis = screensize.Width - screenOffSet;
                    startCoordinates.Y_Axis = screenOffSet;
                    break;
                case StartPoint.TOP_LEFT:
                    startCoordinates.X_Axis = screenOffSet;
                    startCoordinates.Y_Axis = screenOffSet;
                    break;
                case StartPoint.BOTTOM_MIDDLE:
                    startCoordinates.Y_Axis = screensize.Height - screenOffSet;
                    break;
                case StartPoint.BOTTOM_RIGHT:
                    startCoordinates.X_Axis = screensize.Width - screenOffSet;
                    startCoordinates.Y_Axis = screensize.Height - screenOffSet;
                    break;
                case StartPoint.BOTTOM_LEFT:
                    startCoordinates.X_Axis = screenOffSet;
                    startCoordinates.Y_Axis = screensize.Height - screenOffSet;
                    break;
                default:
                    break;
            }
            return startCoordinates;
        }
        private static Coordinates GetEndTouchCoOrdinates(Size screensize, Direction direction, Coordinates startCoordinates, double scrollPercent)
        {
            int border = 10;
            var endCoordinates = new Coordinates();
            switch (direction)
            {
                case Direction.UP:
                    endCoordinates.X_Axis = startCoordinates.X_Axis;
                    endCoordinates.Y_Axis = startCoordinates.Y_Axis - (((screensize.Height - startCoordinates.Y_Axis - border) / 100) * scrollPercent);
                    break;
                case Direction.DOWN:
                    endCoordinates.X_Axis = startCoordinates.X_Axis;
                    endCoordinates.Y_Axis = screensize.Height - (((screensize.Height - startCoordinates.Y_Axis - border) / 100) * scrollPercent);
                    break;
                case Direction.LEFT:
                    endCoordinates.X_Axis = border;
                    endCoordinates.Y_Axis = startCoordinates.Y_Axis;
                    break;
                case Direction.RIGHT:
                    endCoordinates.X_Axis = screensize.Width - border;
                    endCoordinates.Y_Axis = startCoordinates.Y_Axis;
                    break;
                default:
                    throw new Exception("Invalid direction for swipe operation");
            }
            return endCoordinates;
        }
    }
}
