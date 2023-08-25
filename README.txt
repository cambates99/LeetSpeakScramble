README

Summary
	This C# program defines a class called LeetScramble, 
	which performs a text transformation operation where 
	each word in a string is "encoded" based on certain rules.
	example: hello, world -> h3w, w3d
	
Results
	Due to the use of the char HashSet, Regex pattern, and early returns
	the program functions reasonably well. It was able to translate 
	1000 words in ~12ms. All other tests indicate a perfect accuracy.