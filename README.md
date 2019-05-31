# Knn

## Introduction
----
- The basic idea of KNN is that if we have a data set that contains a number of instances of something with a particular value of interest associated with each instance, and we also have an instance that we want to infer the value of interest for (because we don't already have it) - henceforth called the query, then we should expect its value to be similar to that of instances in the data set that are similar to it.

- For example, if we have a data set with houses sold around Seattle and the prices they were sold for, and we want to know how much we can expect to get for a house we are going to sell, then we should expect to get about as much as other houses similar to it have sold for.
----
## Implementation
----
1. Choose a positive integer, k, that is the number of similar houses we will consider.
2. Then find the k most similar houses to the one that we are selling and average their selling prices together. 
3. That average is what we should expect to sell our house for. 

----
## Data Format
----
- The caller will also provide your implementation with the data set of labeled instances.  ("Labeled" means they have values entered for the value of interest...  unlike the query, which is the instance we're trying to find the value of interest for.)

  - Each instance will be a 2-tuple
  - The first item in the tuple is the features for that instance, and the second item is the value of interest, represented as a floating point number.

    - The value of interest will always be a single floating point number - this is one aspect that will not be generic and flexible.
    - (features, 399000.0)
    - features could contain more tuples
  
----
## Running the program

1. On Windows: Create a new F# project in Visual Studio, and replace the code with Knn.fs

2. On Linux/Mac: 
   - In Terminal: Create a new F# project with **dotnet new console -lang F#**
   - Inside the project directory, download the Knn.fs to replace the original source code with the code inside the Knn.fs file
   - To Run: dotnet run
