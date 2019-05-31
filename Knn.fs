(*
Gangyi Yu (Mark)

CPSC3400 - Knn

Since this is a course that requires a significant amount of programming and it is easy to find code for many programming problems on the Internet, 
I want to be explicit about my expectations regarding the code you submit for assignments.  I believe that you can learn a lot from looking at code
written by other people but that you learn very little by simply copying code.  The learning objectives of this course include you learning to write 
and debug programs in Python and F#.  All of the code you turn in must have been written by you without immediate reference to another solution to the 
problem you are solving.  That means that you can look at other programs to see how someone solved a similar problem, but you shouldn't have any code 
written by someone else visible when you write yours (and you shouldn't have looked at a solution just a few seconds before you type!).  You should 
compose the code you write based on your understanding of how the features of the language you are using can be used to implement the algorithm you 
have chosen to solve the problem you are addressing.  Doing it this way is "real programming" - in contrast to just trying to get something to work 
by cutting and pasting stuff you don't actually understand.  It is the only way to achieve the learning objectives of the course.

*)
module knn

open System

///This is a closure function that will accept an integer k , a distant function , and a data set
///This function will return a function to the user, and to retrieve a function to that recieve a single query as parameter
///THe function will accept any type of data in the form of (features, float), features could be a tuple of anything, no length or type restriction
///knn function takes in a number k, distance function for the features, and a list of data
let knn k distance (data : (('a * float) list)) =

    ///Recursive helper function for knn
    ///Taking in k nearest neighbors same type as data, a single instance that has the same type of each element inside the nearest neighbor list and a query that is a feature
    ///Assume the neighbors has exacly K elements
    ///The function should return a list with k elements that has all the neighbors that are closest to the query the curren instance, and the head will be used to construct a new list
    ///Otherwise, it will attach the current instance to the new list, then do a recursive call with head of the list as instance
    let rec insertTopK (neighbors : (('a * float) list)) instance query  = 
        ///Pattern-matching of neighbors to find the top k neighbors that are closest
        ///Return an empty list if the neighbors is empty
        ///Compare the distance between the current instance and the query and the distance between the head and the query
        ///If the former is smaller then do a recursive call, the instance field will be pass in with the head of the list
        match neighbors with
        |[] -> []
        |hd :: tl -> let feature1,_ = instance in let feature2,_ = hd in  
                        if (distance feature2 query) < (distance feature1 query) 
                        then hd :: insertTopK tl instance query
                            else instance :: insertTopK tl hd query

    ///Getting the first K elements from the list
    let firstK = data.[0..(k - 1)] 
    ///Getting the rest of the elements from the list, starting from k
    let restK = data.[k..]

    ///Initially ths will take in the first top k elements, and the rest of the elements from the list and a query to test against
    ///This will genreate differents list until it find the neighbors so far to pass into the insertTopK
    let rec processDataList bestTopK restData query : ('a * float) list = 
        ///Two list pattern-mathing, if both of it is empty, return an empty list
        ///If the rest of the list and the  is empty which means that k == the length of the list, which will return the entire list
        ///Otherwise, it will due the recursive call, and the bestTopK will be replaced as the result returned from the insertTopK, then the rest of the list and the query passed from the user
        match bestTopK, restData with 
        |[],[] -> []
        |_,[] -> bestTopK
        |_, inst :: tl -> processDataList (insertTopK bestTopK inst query) tl query
   

    ///Return the partial function back that accept a single query
    processDataList firstK restK



///This will average the instances passed in, which would return a float
let avgInstances instances =
    ///Recursive helper function to find the average of all the instances, base on the second value follow the feature tuple
    ///Pattern-matching, if the list is empty, determine if the list is originally empty, or empty after recursive call. return 0.0 for the former, and sum/count for ladder
    ///Recursive call would add the number to the sum, then pass it in as param, and increment count by 1.0 (float -> division) and the rest of the list
    let rec avgHelper sum count = function
        |[] -> if count = 0.0 then sum else sum / count
        |hd :: tl -> let _,num = hd in
                        avgHelper (sum + num) (count + 1.0) tl
    ///Return the result by calling the helper function by passing sum and count as 0.0 and the instances 
    avgHelper 0.0 0.0 instances