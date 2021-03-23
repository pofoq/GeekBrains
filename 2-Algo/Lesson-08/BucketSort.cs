using System.Collections.Generic;

namespace Lesson_08
{
    public static class BucketSort
    {
        public static int[] SortArray(int[] startArray, out List<int[]> result)
        {
            result = new List<int[]>();
            if (startArray is null || startArray.Length == 0)
                return null;
            List<int> bucket_1 = new List<int>();
            List<int> bucket_2 = new List<int>();
            List<int> bucket_3 = new List<int>();
            List<int> bucket_4 = new List<int>();
            List<int> bucket_5 = new List<int>();

            for (int i = 0; i < startArray.Length; i++)
            {
                if (startArray[i] < 20)
                    bucket_1.Add(startArray[i]);
                else if (startArray[i] < 40)
                    bucket_2.Add(startArray[i]);
                else if (startArray[i] < 60)
                    bucket_3.Add(startArray[i]);
                else if (startArray[i] < 80)
                    bucket_4.Add(startArray[i]);
                else if (startArray[i] < 100)
                    bucket_5.Add(startArray[i]);
            }

            result.Add(bucket_1.ToArray());
            result.Add(bucket_2.ToArray());
            result.Add(bucket_3.ToArray());
            result.Add(bucket_4.ToArray());
            result.Add(bucket_5.ToArray());

            bucket_1 = SortArray(bucket_1);
            bucket_2 = SortArray(bucket_2);
            bucket_3 = SortArray(bucket_3);
            bucket_4 = SortArray(bucket_4);
            bucket_5 = SortArray(bucket_5);

            result.Add(bucket_1.ToArray());
            result.Add(bucket_2.ToArray());
            result.Add(bucket_3.ToArray());
            result.Add(bucket_4.ToArray());
            result.Add(bucket_5.ToArray());

            List<int> arrayToReturn = MergeArray(bucket_1, bucket_2, bucket_3, bucket_4, bucket_5);
            result.Add(arrayToReturn.ToArray());
            return arrayToReturn.ToArray();
        }

        static private List<int> MergeArray(params List<int>[] lists)
        {
            if (lists is null || lists.Length == 0)
                return null;
            List<int> arrayToReturn = new List<int>();
            for (int i = 0; i < lists.Length; i++)
            {
                if (lists[i] == null)
                    continue;
                for (int j = 0; j < lists[i].Count; j++)
                    arrayToReturn.Add(lists[i][j]);
            }
            return arrayToReturn;
        }

        static private List<int> SortArray(List<int> list)
        {
            if (list is null || list.Count == 0)
                return null;
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    if (i == j)
                        continue;
                    if (list[i] < list[j])
                    {
                        int temp = list[j];
                        list[j] = list[i];
                        list[i] = temp;
                    }
                }
            }
            return list;
        }
    }
}
