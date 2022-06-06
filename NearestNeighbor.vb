Public Class NearestNeighbor
    'convert the bitmap image into an object matrix
    Public Shared Function CreateMatrix(ByVal Image As Bitmap) As Object()()
        Dim Matrix As Object()() = New Object(Image.Width - 1)() {}
        For i = 0 To Image.Width - 1 Step 1
            Matrix(i) = New Object(Image.Height - 1) {}
            For j = 0 To Image.Height - 1 Step 1
                Matrix(i)(j) = Image.GetPixel(i, j)
            Next
        Next
        Return Matrix
    End Function
    'redimension the object matrix, it can be used to other type of data instead of image
    Public Shared Function Redimension(ByVal Matrix As Object()(), ByVal NewWidth As Integer, ByVal NewHeight As Integer) As Object()()
        Dim NewMatrix As Object()() = New Object(NewWidth - 1)() {}
        Dim DeltaX As Double = Double.Parse(NewWidth) / Matrix.Length
        Dim DeltaY As Double = Double.Parse(NewHeight) / Matrix(0).Length
        For i = 0 To NewWidth - 1 Step 1
            NewMatrix(i) = New Object(NewHeight - 1) {}
            For j = 0 To NewHeight - 1 Step 1
                Dim x As Integer = Math.Floor(Double.Parse(i) / DeltaX)
                Dim y As Integer = Math.Floor(Double.Parse(j) / DeltaY)
                NewMatrix(i)(j) = Matrix(x)(y)
            Next
        Next
        Return NewMatrix
    End Function
    'creates an image from a object matrix
    Public Shared Function CreateImage(ByVal Matrix As Object()())
        Dim Image As Bitmap = New Bitmap(Matrix.Length, Matrix(0).Length)
        For i = 0 To Matrix.Length - 1 Step 1
            For j = 0 To Matrix(0).Length - 1 Step 1
                Dim Color As Color = DirectCast(Matrix(i)(j), Color)
                Image.SetPixel(i, j, Color)
            Next
        Next
        Return Image
    End Function
End Class