namespace _04_IntroOOP
{
    /*
     * private (default for all field)
     * public
     * protected
     * internal (видно тільки в межах цієї збірки)
     * protected internal
     
      
     */

    partial class Point
    {
        public void setX(int newX)
        {
            if (newX > 0)
                _xCoord = newX;
            else
                _xCoord = 0;
        }
        public void setY(int newY)
        {
            if (newY > 0)
                _yCoord = newY;
            else
                _xCoord = 0;
        }

        public int getX() { return _xCoord; }
        public int getY() { return _yCoord; }
    }
}
