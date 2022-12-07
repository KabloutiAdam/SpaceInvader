using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyNvader
{
    internal class GroupWall
    {

        private int _id;

        private int _x;

        private int _y;

        private List<Wall> _wallList = new List<Wall>();

        public GroupWall(int id, int x, int y)
        {
            _id = id;
            _x = x;
            _y = y;

            CreateWall();
        }

        public void CreateWall()
        {
            for(int i = 0; i < 17; i++)
            {
                this._wallList.Add(new Wall(this._id * 5 + i, this._x * 7 + i, this._y));
            }
        }

        

        public List<Wall> WallList
        {
            get { return _wallList; }
            set { _wallList = value; }
        }

    }
}
