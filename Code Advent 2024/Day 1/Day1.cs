class Day1 {
    static void Main () {
        string inputPath = "Day 1/input.txt";  
        string readInput = File.ReadAllText(inputPath);   // Read the input file and assign it to a string.

        string addNewlines = readInput.Replace("   ", "\n");   // Replace all triple spaces with a newline.

        string[] newStringArray = addNewlines.Split('\n');   // Split every number into a string element when it encounters a newline char.

        Array.Resize(ref newStringArray, newStringArray.Length - 1);   // Remove the last element caused by newline at the end of the string.

        int[] newIntArray = Array.ConvertAll(newStringArray, int.Parse);   // Convert all string elements into int elements.


        int listLength = newIntArray.Length/2;   // Get half of the full list length, to share between the 2 lists.
        int[] list1 = new int[listLength];
        int[] list2 = new int[listLength];
        
        for (int i = 0; i < listLength; i++) {
            if (i < listLength) {   // Ensure that i never goes beyond array bounds.
                list1[i] = newIntArray[i*2];   // Assign list1 to every even number.
                list2[i] = newIntArray[(i*2)+1];   // Assign list2 to every odd number.
            }
        }


        int[] sortedList1 = list1;   // New sorted lists to preserve old lists.
        int[] sortedList2 = list2;
        Array.Sort(sortedList1);   // Sort lists from lowest to highest number.
        Array.Sort(sortedList2);

        int[] listDifferences = new int[listLength];   // List of the differences between list1 and list2.
        int listResult = 0;   // Used to store result of adding every value in the differences list.
        for (int i = 0; i < listLength; i++) {
            listDifferences[i] = sortedList1[i] - sortedList2[i];
            if (listDifferences[i] < 0) {
                listDifferences[i] *= -1;
            }
            listResult += listDifferences[i];
        }

        Console.WriteLine("Result: " + listResult);


        // for (int i = 0; i < listLength; i++) {
        //     Console.WriteLine(list1[i] + " List 1\n" + list2[i] + " List 2");
        // }


        /*************************************************************************************************/
        /*                                     Advent of Code PART 2                                     */
        /*************************************************************************************************/


        int[] similarityScores = new int[listLength];
        int similarityResult = 0;
        for (int i = 0; i < listLength; i++) {
            int numAmount = 0;   // Used to keep track of how many times a number in the first list repeats in the second list.
            for (int j = 0; j < listLength; j++) {
                if (list1[i] == list2[j]) {
                    numAmount++;   // Add 1 for everytime a repeated number is found in list2.
                }
            }
            similarityScores[i] = list1[i]*numAmount;   // Multiply the number with the amount of times it repeats to get the Similarity Score.
            similarityResult += similarityScores[i];
        }

        Console.WriteLine("Similarity Score: " + similarityResult);
    }
}
