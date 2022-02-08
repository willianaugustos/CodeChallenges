


namespace RotateMatrix
{

    public class Rotate
    {

        public static void Main()
        {

            Console.WriteLine("Rotate the Matrix");

            Console.WriteLine("Enter a number of times you want to rotate");
            var numberOfRotations =1;// Convert.ToInt32(Console.ReadLine());

            var matrix = new List<List<int>>()
        {
            new List<int>() {1, 2, 3, 4},
            new List<int>() {5, 6, 7, 8},
            new List<int>() {9, 10, 11, 12},
            new List<int>() {13, 14, 15, 16}
        };

            ShowMatrix(matrix);
            RotateMatrix(matrix, numberOfRotations);

            Console.WriteLine($"This is the result of {numberOfRotations} rotations on the Matrix:");
            ShowMatrix(matrix);


            void ShowMatrix(List<List<int>> matrix)
            {
                for (var i = 0; i < matrix.Count(); i++)
                {
                    for (int j = 0; j < matrix[i].Count(); j++)
                    {
                        Console.Write(matrix[i][j].ToString().PadLeft(3, ' '));
                        Console.Write(" ");
                    }
                    Console.WriteLine("");
                }
            }


            void RotateMatrix(List<List<int>> matrix, int numberOfRotations)
            {
                //identity the number of rectangles
                //run through the lines up-down

                //take the line 0 to measure the total of lines
                int _topLeftLine=0;
                int _topLeftColumn=0;
                
                int _topRightLine=0;
                int _topRightColumn=matrix[0].Count()-1;

                int _bottomLeftLine=matrix.Count()-1;
                int _bottomLeftColumn=0;
                
                int _bottomRightLine=matrix.Count()-1;
                int _bottomRightColumn=matrix[0].Count()-1;

                var rectangles = new List<Corners>();

                bool stop = false;
                while (!stop)
                {
                    var rectangle = new Corners( 
                            new Corner(_topLeftLine, _topLeftColumn), 
                            new Corner(_topRightLine, _topRightColumn), 
                            new Corner(_bottomLeftLine, _bottomLeftColumn), 
                            new Corner(_bottomRightLine, _bottomRightColumn));
                    rectangles.Add(rectangle);

                    _topLeftLine++;
                    _topLeftColumn++;

                    _topRightLine++;
                    _topRightColumn--;
                    
                    _bottomLeftLine--;
                    _bottomLeftColumn++;

                    _bottomRightLine--;
                    _bottomRightColumn--;

                    //check if lines meet and then stop the loop
                    if (_bottomLeftLine <= _topLeftLine)
                        stop=true;

                    if (_bottomRightColumn <= _bottomLeftColumn)
                        stop = true;

                }


                //rotate "r" times
                for (int r = 0; r < numberOfRotations; r++)
                {
                
                   foreach(var rectangle in rectangles)   
                   {
                       Console.WriteLine($"Encontrei um retangulo começando em :{rectangle.topLeft.x},{rectangle.topLeft.y}, começando a rotacionar...");
                       var saveTopLeft = matrix[rectangle.topLeft.x][rectangle.topLeft.y];

                       //move first line from right to left
                       for (int position=rectangle.topLeft.x; position <= rectangle.topRight.x -1; position++)
                       {
                            matrix[rectangle.topLeft.y][position] = matrix[rectangle.topLeft.y][position+1];
                       }

                       //move last column bottom to top
                       for(int position2=rectangle.topRight.y; position2<= rectangle.bottomRight.y -1; position2++)
                       {
                           Console.WriteLine($"topRight.x={rectangle.topRight.x}");
                           matrix[position2][rectangle.topRight.x] = matrix[position2+1][rectangle.topRight.x];
                       }

                       //move last line from left to right
                       for (int position=rectangle.bottomRight.x; position >= rectangle.bottomLeft.x+1; position--)
                       {
                           matrix[rectangle.bottomRight.y][position]=matrix[rectangle.bottomRight.y][position-1];
                       }

                       //move first colum from top to bottom
                       for (int position=rectangle.bottomLeft.y;position>=rectangle.topLeft.y+1;position--)
                       {
                           matrix[position][rectangle.topLeft.x] = matrix[position-1][rectangle.topLeft.x];
                       }

                       //set back the saved item to properly position (relative 0,1)
                        matrix[rectangle.topLeft.y+1][rectangle.topLeft.x] = saveTopLeft;
                   }
                }
            }
        }

        class Corner{
            public int x {get; private set;}
            public int y {get; private set;}

            public Corner(int x, int y)
            {
                this.x=x;
                this.y=y;
            }
        }

        class Corners
        {
            public Corner topLeft {get; private set;}
            public Corner bottomLeft {get; private set;}
            public Corner topRight {get; private set;}
            public Corner bottomRight {get; private set;}

            public Corners(Corner _topLeft, Corner _bottomLeft, Corner _topRight, Corner _bottomRight)
            {
                this.topLeft = _topLeft;
                this.bottomLeft = _bottomLeft;
                this.topRight = _topRight;
                this.bottomRight = _bottomRight;
            }
        }
    }
}