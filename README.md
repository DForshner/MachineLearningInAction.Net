# MachineLearningInAction.Net

## About

This is C# port of the source code from Peter Harrington's Machine Learning in Action book http://manning.com/pharrington/

The original Python source can be found at https://github.com/pbharrin/machinelearninginaction

I really recommend buying his book if you are interested in machine learning but find the academic math first approach isn't working for you.  It takes a lot of the "magic" out of machine learning and leaves you with fairly straightforward code.   

I'm hoping to stay somewhat close to the original python code but MathNet.Numerics is not quite the same as NumPy and OxyPlot + WPF requires more framework boilerplate than Pyplot.  I'm not terribly interested in WPF so don't expect anything fancy.  This is just going to open a bunch of WPF windows that mimic the pyplot outputs and there are some unit tests to mimic any console outputs.

# Running the code

- Every chapter has a solution file so just open it and run it in debug mode.  
- If there are any special instructions (like unzipping datasets) they will be listed in the chapter's README file.

# Nuget Dependancies:
- MathNet.Numerics
- OxyPlot