# Binary.Files

Using bitwise operators and Binary file formats.  

## Background 
We've been looking at using the `&`, `|` and `^` operators to perform bitwise operators on integer values (stored in binary, displayed in denary). 

The BMP file format is summarised [here](http://www.fastgraph.com/help/bmp_header_format.html).


## Tasks 

Using the System.File object (and its ReadAllBytes function) unpack this bitmap file and summarise its header's data. (As with the text files, it might be easier to debug if you copy the files into the bin/Debug/version/ folder.)

### Validation 

The code should first validate that it is actually a bitmap. 

### Summary

This summary should include: dimensions, colour summary and so on. 

1. What are the dimensions of the image  
1. How many colours are displayed
1. What is the most common colour. 

### JPG/PNG/etc.

Can you do similar with a different data type. 

## Extension

In previous exercises we've looked at how to sets bits. 

In a bitmap file, each 24-bit colour code has a byte of Red, Green and Blue. If you flip the least significant bit of each byte, will the resulting file look like it has been changed? 

At the primary level, changing a particular byte somewhere in the image to an ascii value of a character would suffice, but it is likely to end up with an obvious flaw in the image.

At a secondary level, you should be able to change individual bits - which would be less visible to the human eye.


### 1. Steganography 

[Steganography](https://en.wikipedia.org/wiki/Steganography) is the practice of hiding a message within a larger object. 

#### Write 

Take a bitmap (i.e. the name of a file) and a phrase and rewrite the bitmap file by encoding the ASCII codes for the phrase's symbols in the LSBs of the colour (or even whole bytes), in effect 'hiding' the word in the outputted file. 

#### Read 

A second function should take in the name of the written file and return the word that was hidden.


### 2. With a JPG

This is harder. 

Do the same but for the attached JPG file.
