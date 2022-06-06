from PIL import Image, ImageDraw
class NearestNeighbor:
    #convert the bitmap image into an object matrix
    @staticmethod
    def create_matrix(image):
        width, height = image.size
        matrix = []
        for i in range(width):
            matrix.append([])
            for j in range(height):
                r, g, b = image.getpixel((i, j))
                color = (r, g, b)
                matrix[i].append(color)
        return matrix
    #redimension the object matrix, it can be used to other type of data instead of image
    @staticmethod
    def redimension(matrix, new_width, new_height):
        new_matrix = []
        delta_x = float(new_width) / len(matrix)
        delta_y = float(new_height) / len(matrix[0])
        for i in range(new_width):
            new_matrix.append([])
            for j in range(new_height):
                x = int(i / delta_x)
                y = int(j / delta_y)
                new_matrix[i].append(matrix[x][y])
        return new_matrix
    #creates an image from a object matrix
    @staticmethod
    def create_image(matrix):
        image = Image.new('RGB', (len(matrix), len(matrix[0])), color='white')
        for i in range(len(matrix)):
            for j in range(len(matrix[0])):
                image.putpixel((i, j), matrix[i][j])
        return image