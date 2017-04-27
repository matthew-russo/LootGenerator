using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RandomizationKit
{
    public class RandomFuncs : MonoBehaviour
    {
        public Text ResultText;

        public void flipCoin()
        {
            string result = "";
            if (Random.value <= 0.5f)
            {
                result = "HEADS";
            }
            else
            {
                result = "TAILS";
            }
            ResultText.text += result + " ";
        }

        public void rollTwoDice()
        {
            int[] possibleValues = new int[]
            {
            2,
            3,3,
            4,4,4,
            5,5,5,5,
            6,6,6,6,6,
            7,7,7,7,7,7,
            8,8,8,8,8,
            9,9,9,9,
            10,10,10,
            11,11,
            12
            };

            int ourValue = possibleValues[Random.Range(0, possibleValues.Length)];

            ResultText.text += ourValue + " ";
        }

        public void Shuffle(string[] list)
        {
            for (int i = 0; i < list.Length * 10; i++)
            {
                int randIndex1 = Random.Range(0, list.Length);
                int randIndex2 = Random.Range(0, list.Length);

                string tempShuffleSpace = list[randIndex1];
                list[randIndex1] = list[randIndex2];
                list[randIndex2] = tempShuffleSpace;
            }
        }

        public void FYShuffle(List<string> list)
        {
            for (int i = list.Count - 1; i >= 1; i--)
            {
                int randomIndex = Random.Range(0, i + 1);
                string tempShuffleSpace = list[randomIndex];
                list[randomIndex] = list[i];
                list[i] = tempShuffleSpace;
            }
        }

        public class WeightedString
        {
            public string stringValue;
            public float weight;
        }

        public void SimpleWeightedShuffle(List<string> list, List<float> weights)
        {
            if (list.Count != weights.Count)
            {
                throw new UnityException("Lists were not the same size oh no!!!");
            }

            List<float> newWeights = new List<float>(weights);

            for (int i = 0; i < newWeights.Count; i++)
            {
                newWeights[i] *= Random.value;
            }

            List<WeightedString> weightedStrings = new List<WeightedString>();

            for (int i = 0; i < list.Count; i++)
            {
                WeightedString newWeightedString = new WeightedString();
                newWeightedString.stringValue = list[i];
                newWeightedString.weight = newWeights[i];
                weightedStrings.Add(newWeightedString);
            }

            // TODO: Uniform shuffle the weighted strings

            weightedStrings.Sort(CompareWeightedStrings);

            for (int i = 0; i < weightedStrings.Count; i++)
            {
                list[i] = weightedStrings[i].stringValue;
            }
        }

        public int CompareWeightedStrings(WeightedString s1, WeightedString s2)
        {
            if (s1.weight < s2.weight)
            {
                return -1;
            }
            else if (s1.weight > s2.weight)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public void GeometricWeightedShuffle(List<string> list, float coinWeight)
        {
            FYShuffle(list);
            list.Sort();

            List<string> shuffledList = new List<string>();

            while (list.Count > 0)
            {
                int currentIndex = 0;

                while (currentIndex < list.Count - 1)
                {
                    if (Random.value <= coinWeight)
                    {
                        break;
                    }
                    currentIndex++;
                }
                shuffledList.Add(list[currentIndex]);
                list.RemoveAt(currentIndex);
            }

            foreach (string item in shuffledList)
            {
                list.Add(item);
            }
        }

        //public void ShuffleDeck()
        //{
        //    Clear();

        //    List<float> letterWeights = new List<float>();
        //    for (int i = 0; i < alphabet.Count; i++)
        //    {
        //        letterWeights.Add((float)(i + 1f));
        //    }

        //    GeometricWeightedShuffle(letterWeights, 0.5f);
        //    foreach (string item in letterWeights)
        //    {
        //        ResultText.text += card + ", ";
        //    }
        //}

        private string[] _deck =
        {
        "A <3's",
        "A Clubs",
        "A <>'s",
        "A Spades",
        "2 <3's",
        "2 Clubs",
        "2 <>'s",
        "2 Spades",
        "3 <3's",
        "3 Clubs",
        "3 <>'s",
        "3 Spades",
        "4 <3's",
        "4 Clubs",
        "4 <>'s",
        "4 Spades",
        "5 <3's",
        "5 Clubs",
        "5 <>'s",
        "5 Spades",
        "6 <3's",
        "6 Clubs",
        "6 <>'s",
        "6 Spades",
        "7 <3's",
        "7 Clubs",
        "7 <>'s",
        "7 Spades",
        "8 <3's",
        "8 Clubs",
        "8 <>'s",
        "8 Spades",
        "9 <3's",
        "9 Clubs",
        "9 <>'s",
        "9 Spades",
        "10 <3's",
        "10 Clubs",
        "10 <>'s",
        "10 Spades",
        "J <3's",
        "J Clubs",
        "J <>'s",
        "J Spades",
        "Q <3's",
        "Q Clubs",
        "Q <>'s",
        "Q Spades",
        "K <3's",
        "K Clubs",
        "K <>'s",
        "K Spades"
    };

        public List<string> alphabet = new List<string>();

        public void Clear()
        {
            ResultText.text = "";
        }




        /// <summary>
        /// GENERIC RANDOM FUNCTIONS
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>


        public static T RandomElement<T>(T[] array)
        {
            int randomIndex = Random.Range(0, array.Length);
            return array[randomIndex];
        }

        public static T RandomElement<T>(List<T> list)
        {
            int randomIndex = Random.Range(0, list.Count);
            return list[randomIndex];
        }

        public static void FYShuffle<T>(T[] array)
        {
            for (int i = array.Length - 1; i >= 1; i--)
            {
                int randomIndex = Random.Range(0, i + 1);
                T tempShuffleSpace = array[randomIndex];
                array[randomIndex] = array[i];
                array[i] = tempShuffleSpace;
            }
        }

        public static void FYShuffle<T>(List<T> list)
        {
            for (int i = list.Count - 1; i >= 1; i--)
            {
                int randomIndex = Random.Range(0, i + 1);
                T tempShuffleSpace = list[randomIndex];
                list[randomIndex] = list[i];
                list[i] = tempShuffleSpace;
            }
        }

        public static void GeometricShuffle<T>(List<T> list, System.Comparison<T> compareFunc, float coinWeight)
        {
            FYShuffle(list);
            list.Sort(compareFunc);

            List<T> shuffledList = new List<T>();

            while (list.Count > 0)
            {
                int currentIndex = 0;

                while (currentIndex < list.Count - 1)
                {
                    if (Random.value <= coinWeight)
                    {
                        break;
                    }
                    currentIndex++;
                }
                shuffledList.Add(list[currentIndex]);
                list.RemoveAt(currentIndex);
            }

            foreach (T item in shuffledList)
            {
                list.Add(item);
            }
        }
    }
}
