//그래프의 도달 가능성
//DAG만 해당
using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

public class qb 
{
    static List<int>[] adj = new List<int>[6];
	public static void Main(string[] args) {
        //인접 리스트 초기화
        for(int i = 0; i < 6; i++){
            adj[i] = new List<int>();
        }

        adj[1].Add(3);
        adj[1].Add(2);
        adj[3].Add(4);
        adj[2].Add(4);
        adj[2].Add(5);
        adj[4].Add(5);

        //도달 가능한 노드를 체크할 bitarray
        //a에서 b로 갈 수 있을 경우 bit[a][b] = 1로 설정
        BitArray[] bit = new BitArray[6];
        for(int i = 0; i < bit.Length; i++){
            bit[i] = new BitArray(5);
        }
        
        for(int x = 5; x >= 1; x--){
            bit[x][x-1] = true;
            foreach(var u in adj[x]){
                bit[x] = bit[x].Or(bit[u]);
            }
        }

        for(int i = 1; i <= 5; i++){
            int count = 0;            
            for(int j = 0; j < bit[1].Length; j++){
                if(bit[i][j]) count++;
            }
            Console.WriteLine(i + " : " + count);
        }
    }
}