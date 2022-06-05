//converts image into matrix
function createMatrix(canvas, imgWidth, imgHeight) {
    var matrix = [];
    var imageContext = canvas.getContext('2d');
    var imageData = imageContext.getImageData(0, 0, imgWidth, imgHeight);
    var pixelsData = imageData.data;
    for (var x = 0; x < imgWidth; x++) {
        let row = [];
        for (var y = 0; y < imgHeight; y++) {
            let index = x * imgHeight * 4 + y * 4;
            row.push({ red: pixelsData[index], green: pixelsData[index + 1], blue: pixelsData[index + 2] })
        }
        matrix.push(row);
    }
    return matrix;
}
//converts matrix into image 
function createImage(matrix, canvas) {
    canvas.height = matrix.length;
    canvas.width = matrix[0].length;
    var ctx = canvas.getContext('2d');
    var pixelData = ctx.createImageData(matrix[0].length, matrix.length);
    const height_ = matrix[0].length;
    for (var i = 0; i < matrix.length; i++) {
        for (var j = 0; j < height_; j++) {
            pixelData.data[i * height_ * 4 + j * 4] = matrix[i][j].red;
            pixelData.data[i * height_ * 4 + j * 4 + 1] = matrix[i][j].green;
            pixelData.data[i * height_ * 4 + j * 4 + 2] = matrix[i][j].blue;
            pixelData.data[i * height_ * 4 + j * 4 + 3] = 255;
        }
    }
    ctx.putImageData(pixelData, 30, 30);
}
//interpolates matrix 
function redimension(matrix, newWidth, newHeight) {
    let newMatrix = [];
    let deltaX = newWidth / matrix.length;
    let deltaY = newHeight / matrix[0].length;
    for (var i = 0; i < newWidth; i++) {
        let row = [];
        for (var j = 0; j < newHeight; j++) {
            let x = Math.floor(i / deltaX);
            let y = Math.floor(j / deltaY);
            row.push(matrix[x][y]);
        }
        newMatrix.push(row);
    }
    return newMatrix;
}