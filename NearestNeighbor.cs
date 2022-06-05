using System;
using System.Drawing;
class NearestNeighbor
    {
        //convert the bitmap image into an object matrix
        public static Object[][] createMatrix(Bitmap image)
        {
            Object[][] matrix = new Object[image.Width][];
            for(int i = 0; i < image.Width; i++)
            {
                matrix[i] = new Object[image.Height];
                for(int j = 0; j < image.Height; j++)
                {
                    matrix[i][j] = image.GetPixel(i, j);
                }
            }
            return matrix;
        }
        //redimension the object matrix, it can be used to other type of data instead of image
        public static object[][] redimension(object[][] matrix, int newWidth, int newHeight)
        {
            object[][] newMatrix = new object[newWidth][];
            double deltaX = (Convert.ToDouble(newWidth) / matrix.Length);
            double deltaY = (Convert.ToDouble(newHeight) / matrix[0].Length);
            for(int i = 0; i < newWidth; i++)
            {
                newMatrix[i] = new object[newHeight];
                for (int j = 0; j < newHeight; j++)
                {
                    int x = (int)Math.Floor(Convert.ToDouble(i) / deltaX) ;
                    int y = (int)Math.Floor(Convert.ToDouble(j) / deltaY);
                    newMatrix[i][j] = matrix[x][y];
                }
            }
            return newMatrix;
        }
        //creates an image from a object matrix
        public static Bitmap createImage(object[][] matrix)
        {
            Bitmap image = new Bitmap(matrix.Length, matrix[0].Length);
            for(int i = 0; i < matrix.Length; i++)
            {
                for(int j = 0; j < matrix[0].Length; j++)
                {
                    image.SetPixel(i, j, (Color)matrix[i][j]);
                }
            }
            return image;
        }
    }
