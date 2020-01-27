//나이트 투어 : n*n 체스판에서 나이트를 체스의 규칙에 맞게 움직이면서
//모든 칸을 정확히 한 번 방문하는 경로
//시작했던 칸으로 돌아올 수 있는 경우를 닫힌 나이트 투어, 그렇지 않은 경우를 열린 나이트 투어라고 함

//체스판의 각 칸이 노드가 되고, 나이트가 체스의 규칙에 따라 두 칸 사이를 이동할 수
//있는 경우를 간선으로 연결한 그래프를 생각하면, 나이트 투어는 이 그래프의 '해밀턴 경로에 대응
//퇴각검색 알고리즘으로 해결하자

//바른스도르프 규칙(Warnsdorf's rule) : 나이트 투어를 찾기 위한 간단하고 효율적인
//휴리스틱으로, 다음으로 움직일 수 있는 경우가 가장 적은 곳으로 움직이는 것
using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;

public class Lecture 
{
    //체스판
    static int[,] chess;
    
    static int[] dx = new int[]{-1, -1, 1, 1, -2, -2, 2, 2};
    static int[] dy = new int[]{2, -2, 2, -2, 1, -1, 1, -1};
    
    //배열의 index에는 현재 위치의 좌표가 들어가고 그 좌표의 리스트에는
    //갈수 있는 좌표와 그 좌표에서 갈 수 있는 위치의 개수가 들어간다.
    static List<(int,int,int)>[,] list;
    
    public static void Main(string[] args) {
        //5*5체스판으로 가정
        chess = new int[5,5];
        
        Init(5);
  
        chess[1,1] = 1;
        KnightTour(1,1,1);

        for(int i = 0; i < chess.GetLength(0); i++){
            for(int j = 0; j < chess.GetLength(0); j++){
                Console.Write(chess[i,j] + " ");
            }
            Console.WriteLine();
        }
    }

    //리스트 만들기를 건너뛸지를 체크할 배열
    //한번 만들었으면 건너뛴다.
    static bool[,] IsFinished;

    public static bool KnightTour(int x, int y, int count){
        int max = chess.GetLength(0);
        //count 번호가 n*n개의 체스칸의 마지막 칸에 도달하면 종료
        if(count == max*max){
            chess[x,y] = count;
            return true;
            }
        
        //바른스도르프 규칙을 이용하여 list를 만든다.
        //c#에는 우선순위 큐가 없으므로 list를 sort함수로 정렬해준다.
        if(!IsFinished[x,y]){
            for(int i = 0; i < dx.Length; i++){
                int nx = x + dx[i];
                int ny = y + dy[i];
                int val = 0;
                if(Chk(nx, ny)){
                    for(int j = 0; j < dx.Length; j++){
                        int tx = nx + dx[i];
                        int ty = ny + dy[i];
                        if(Chk(tx, ty)){
                            val++;
                        }
                    }

                    list[x,y].Add((nx, ny, val));
                }
            }
            list[x,y].Sort((x3, y3) => { if(x3.Item3 > y3.Item3) return 1; 
                                       else if(x3.Item3 < y3.Item3) return -1;
                                       return 0; });
            IsFinished[x,y] = true;
        }
        foreach(var u in list[x,y]){
            int nx = u.Item1;
            int ny = u.Item2;
            if(Chk(nx, ny)){
                chess[x,y] = count;
                if(KnightTour(nx,ny,count+1)) return true;
            	else{
            		chess[x,y] = 0;
            	}
            }
        }
        //새로 간 지점이 실패하면 돌아와서 다시 빈 공간을 체크해야 하므로 clear해준다.
        list[x,y].Clear();
        IsFinished[x,y] = false;
        return false;
    }

    static bool Chk(int x, int y)
    {
        if ((0 <= x && x < chess.GetLength(0)) && (0 <= y && y < chess.GetLength(0)) && (chess[x,y] == 0)){
            return true;
        }
        return false;
    }
    
    static void Init(int n){
    	list = new List<(int,int,int)>[n+1,n+1];
        IsFinished = new bool[n+1,n+1];
    	for(int i = 0; i <= n; i++){
    		for(int j = 0; j <= n; j++){
    			list[i,j] = new List<(int,int,int)>();
    		}
    	}
    }
}