<?php
class NearestNeighbor
{
    #convert the bitmap image into an object matrix
    public static function create_matrix($file_name)
    {
        $matrix = array();
        list($width, $height, $type, $attr) = getimagesize($file_name);
        if (strpos($file_name, "jpg") !== false) {
            $image = imagecreatefromjpeg($file_name);
        } else if (strpos($file_name, "png") !== false) {
            $image = imagecreatefrompng($file_name);
        } else {
            throw new Exception("File not supported.");
        }
        for ($i = 0; $i < $width; $i++) {
            array_push($matrix, array());
            for ($j = 0; $j < $height; $j++) {
                $rgb = imagecolorat($image, $i, $j);
                $red = ($rgb >> 16) & 255;
                $green = ($rgb >> 8) & 255;
                $blue = $rgb & 255;
                array_push($matrix[count($matrix) - 1], array("red" => $red, "green" => $green, "blue" => $blue));
            }
        }
        return $matrix;
    }
    #redimension the object matrix, it can be used to other type of data instead of image
    public static function redimension($matrix, $new_width, $new_height)
    {
        $new_matrix = array();
        $delta_x = $new_width / count($matrix);
        $delta_y = $new_height / count($matrix[0]);
        for ($i = 0; $i < $new_width; $i++) {
            array_push($new_matrix, array());
            for ($j = 0; $j < $new_height; $j++) {
                $x = floor($i / $delta_x);
                $y = floor($j / $delta_y);
                array_push($new_matrix[count($new_matrix) - 1], $matrix[$x][$y]);
            }
        }
        return $new_matrix;
    }
    #Creates an image from a object matrix
    public static function create_image($matrix)
    {
        $image = imagecreatetruecolor(count($matrix), count($matrix[0]));
        for ($i = 0; $i < count($matrix); $i++) {
            for ($j = 0; $j < count($matrix[0]); $j++) {              
                $color = imagecolorallocate($image, $matrix[$i][$j]["red"], $matrix[$i][$j]["green"], $matrix[$i][$j]["blue"]);
                imagesetpixel($image, $i, $j, $color);
            }
        }
        header('Content-Type: image/png');
        imagepng($image);
    }
}