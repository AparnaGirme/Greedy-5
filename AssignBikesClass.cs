public class Solution {
    //TC => O(mn)
    //SC => O(mn)
    public int[] AssignBikes(int[][] workers, int[][] bikes) {
        if(workers == null || workers.Length == 0 || bikes == null || bikes.Length == 0){
            return new int[0];
        }
        int n = workers.Length;
        int m = bikes.Length;
        Dictionary<int, List<int[]>> map = new Dictionary<int, List<int[]>>();
        int[] result = new int[n];
        bool[] assignedBikes = new bool[m];
        bool[] assignedWorkers = new bool[n];
        int minKey = Int32.MaxValue;
        int maxKey = Int32.MinValue;

        for(int i = 0; i< n; i++){
            for(int j = 0; j < m; j++){
                int distance = FindManhattanDistance(workers[i], bikes[j]);
                minKey = Math.Min(minKey, distance);
                maxKey = Math.Max(maxKey, distance);
                if(!map.ContainsKey(distance)){
                    map.Add(distance, new List<int[]>());
                }
                map[distance].Add([i,j]);
            }
        }
        int count = n;
        for(int k = minKey; k <= maxKey; k++){
            if(!map.ContainsKey(k)){
                continue;
            }
            List<int[]> list = map[k];
            for(int i = 0; i < list.Count; i++){
                if(!assignedWorkers[list[i][0]] && !assignedBikes[list[i][1]]){
                    result[list[i][0]] = list[i][1];
                    assignedWorkers[list[i][0]] = true;
                    assignedBikes[list[i][1]] = true;
                    count--;
                    if(count == 0){
                        break;
                    }
                }
            }
        }
        return result;
    }
    //TC => O(mn logmn)
    //SC => O(mn)
    public int[] AssignBikes1(int[][] workers, int[][] bikes) {
        if(workers == null || workers.Length == 0 || bikes == null || bikes.Length == 0){
            return new int[0];
        }
        int n = workers.Length;
        int m = bikes.Length;
        SortedDictionary<int, List<int[]>> map = new SortedDictionary<int, List<int[]>>();
        int[] result = new int[n];
        bool[] assignedBikes = new bool[m];
        bool[] assignedWorkers = new bool[n];

        for(int i = 0; i< n; i++){
            for(int j = 0; j < m; j++){
                int distance = FindManhattanDistance(workers[i], bikes[j]);
                if(!map.ContainsKey(distance)){
                    map.Add(distance, new List<int[]>());
                }
                map[distance].Add([i,j]);
            }
        }
        
        int count = n;
        foreach(var kv in map){
            List<int[]> list = kv.Value;
            for(int i = 0; i < list.Count; i++){
                if(!assignedWorkers[list[i][0]] && !assignedBikes[list[i][1]]){
                    result[list[i][0]] = list[i][1];
                    assignedWorkers[list[i][0]] = true;
                    assignedBikes[list[i][1]] = true;
                    count--;
                    if(count == 0){
                        break;
                    }
                }
            }
        }
        return result;
    }

    public int FindManhattanDistance(int[] worker, int[] bike){
        return Math.Abs(worker[0] - bike[0]) + Math.Abs(worker[1] - bike[1]);
    }
}