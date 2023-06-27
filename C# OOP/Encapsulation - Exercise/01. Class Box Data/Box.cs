using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBoxData
{
    public class Box
    {
        public Box(double lenght, double width, double height)
        {
            Lenght = lenght;
            Width = width;
            Height = height;
        }

        private double lenght;
		public double Lenght
		{
			get 
			{ 
				return lenght; 
			}
			set 
			{ 
				if (value <= 0) 
				{
                    throw new ArgumentException($"Lenght cannot be zero or negative");
                }
                lenght = value;
            }
		}

		private double width;
		public double Width
		{
            get
            {
                return width;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Width cannot be zero or negative");
                }
                width = value;
            }
        }

		private double height;

		public double Height
		{
            get
            {
                return height;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Height cannot be zero or negative");
                }
                height = value;
            }
        }

        public double SurfaceArea()
        {
            return (2 * Lenght * Height) + LateralSurfaceArea();
        }

        public double LateralSurfaceArea()
        {
            return (2 * Lenght * Height) + (2 * Width * Height);
        }

        public double Volume()
        {
            return Lenght * Height * Width;
        }

	}
}
