
using Learning.HomeWorks;

var path = "D:\\TestImage.png";
var pathForNewImage = "D:\\ImageFromBas64.png";

var imageBase64 = ImageToBase64HomeWork.ConvertFromImageToBase64(path);
Console.WriteLine(imageBase64);

await ImageToBase64HomeWork.ConvertFromBase63ToImageAsync(imageBase64,pathForNewImage);

