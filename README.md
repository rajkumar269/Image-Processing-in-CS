**# Image-Processing-in-C#**

This repository is designed for applying image processing techniques.

Stereovision is a typical problem in computer vision and in 3D reconstruction. Given two images - called left and right images - capturing a scene at the same time from two points of view, stereo techniques aim at defining conjugate pairs of pixels, one in each image, that correspond to the same spatial point in the scene. The difference between positions of conjugate pixels, called the disparity, yields the depth of the point in the 3D scene.

These techniques can be implemented in both Unmanned Ground  & Aerial vehicles to process the images which are captured to detect an obstacle.

![ugv](https://user-images.githubusercontent.com/33545271/39442904-b89ac54c-4caa-11e8-81ff-73e50dbc3637.PNG)

The following C# code can be incorporated to apply a filter to an image, extracting image features, etc. using C#.

**ApplyColorToImage:** 
Differentiate the captured image with color to highlight the obstacle.

![applytocolor](https://user-images.githubusercontent.com/33545271/39443436-862129ba-4cac-11e8-94ce-47c427a7b159.PNG)
   
**ColorExtractionFromImage:**
The color extraction will pull the most common colors out of an image file

![colorextractionfromimage](https://user-images.githubusercontent.com/33545271/39443467-a00ef924-4cac-11e8-8aa7-386d6ca0d198.PNG)
  
**CreateBiTonalImage:**
An image or file comprised of a pixel or dot values of either black or white. Bi-tonal (black and white only, one bit per pixel). A Bi-tonal image is created by a thresholding process from a greyscale input, either during the scanning process or subsequently. thresholding is an irreversible process which results in speckled images with noticeably “stair-stepped” diagonal lines.   

![createbitonalimage](https://user-images.githubusercontent.com/33545271/39443476-aa528aa4-4cac-11e8-9b48-5b25e757718a.PNG)

**CreateGammaImage:**
Gamma correction, or often simply gamma, is a nonlinear operation used to encode and decode luminance values in still image systems.

![creategammaimage](https://user-images.githubusercontent.com/33545271/39443505-bfeb53f0-4cac-11e8-815b-e5a118ce9e51.PNG)
  
**GrayscaleTheImage:**
Greyscale image is one in which the value of each pixel is a single sample representing only an amount of light, that is, it carries only intensity information. 

![grayscaletheimage](https://user-images.githubusercontent.com/33545271/39443513-c5384836-4cac-11e8-9b5c-1f066ce7cbe7.PNG)

**GridPixelateTheImage:**
In computer graphics, pixelation (or pixelation in British English) is caused by displaying a bitmap or a section of a bitmap at such a large size that individual pixels, small single-colored square display elements that comprise the bitmap, are visible. Such an image is said to be pixelated in grids.

![gridpixelate](https://user-images.githubusercontent.com/33545271/39443523-ca1ea2fa-4cac-11e8-92cd-66c127512ade.PNG)
  
**InvertImage:**
Inverts the gray values of an image.

![invertimage](https://user-images.githubusercontent.com/33545271/39443526-d055421e-4cac-11e8-9757-10b3e80c8b6a.PNG)
  
**JitterImage:**
An artistic effect can be applied to an image by replacing each pixel with a random pixel from a neighborhood of the specified radius. This is called a jitter filter in some image processing contexts.

![jitterimage](https://user-images.githubusercontent.com/33545271/39443532-d5214374-4cac-11e8-9104-3587682b9f3d.PNG)
  
**ResizeImage:**
Changing the size at which the image will print without changing the number of pixels in the image —instead, the pixels are printed further apart or closer together. Resizing an image will not affect screen display. 

![resize](https://user-images.githubusercontent.com/33545271/39443538-d91e67f4-4cac-11e8-84f2-cfa39cc15ee8.PNG)
  
**SepiaToImage:**
Sepia is a form of photographic print toning – a tone added to a black and white photograph in the darkroom to “warm” up the tones (though since it is still a monochromatic image it is still considered black and white).

![sepiaimg](https://user-images.githubusercontent.com/33545271/39443545-de7d7be0-4cac-11e8-9ae6-90a017f6f869.PNG)
  
**SetBrightnessForImage:**
Adjust the brightness of a picture.

![setbrightness](https://user-images.githubusercontent.com/33545271/39443554-e33b89a6-4cac-11e8-8ddb-4c00415f68b4.PNG)
  
**SetContrastForImage:**
Adjust the contrast of a picture.

![setcontrast](https://user-images.githubusercontent.com/33545271/39443564-e86c2d22-4cac-11e8-90ab-e12909fcb36a.PNG)
  
**SphereEffectForImage:**
Imagine the 2D/3D images on to the surface of a sphere.

![spehere](https://user-images.githubusercontent.com/33545271/39443575-ed9c6708-4cac-11e8-8d4b-5ba4d4b32a28.PNG)
  
**SubstitutionColorInImage:**
Colour replacement in the image

![substitute](https://user-images.githubusercontent.com/33545271/39443986-1b5bf6c6-4cae-11e8-80d8-801826a99381.PNG)
  
**ThresholdToImage:**
Automatic Thresholding is a great way to extract useful information encoded into pixels while minimizing background noise. This is accomplished by utilizing a feedback loop to optimize the threshold value before converting the original greyscale image to binary.

![thresehold](https://user-images.githubusercontent.com/33545271/39443581-f173d7da-4cac-11e8-83d8-17001c64bee2.PNG)
  
**TimeWarpForImage:**
Timewarp / Time warping also known as Reprojection is a technique in VR that warps the rendered image before sending it to the display to correct for the head movement occurred after the rendering. Timewarp can reduce latency and increase or maintain frame rate. 
  
![timewarp](https://user-images.githubusercontent.com/33545271/39443587-f6058bf4-4cac-11e8-92b7-15c3e8a96ae8.PNG)
