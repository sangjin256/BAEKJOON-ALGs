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
    public static void Main(string[] args) {
        //5*5체스판으로 가정
        chess = new int[8,8];
  
        chess[0,0] = 1;
        KnightTour(0,0,1);

        for(int i = 0; i < chess.GetLength(0); i++){
            for(int j = 0; j < chess.GetLength(0); j++){
                Console.Write(chess[i,j] + " ");
            }
            Console.WriteLine();
        }
    }

    public static bool KnightTour(int x, int y, int count){
    	int max = chess.GetLength(0);
        if(count == max*max){
            chess[x,y] = count;
            return true;
        }

        int minVal = dx.Length;
        int minIdx = 0;
		
		int nx;
		int ny;
        for(int i = 0; i < dx.Length; i++){
            nx = x + dx[i];
            ny = y + dy[i];
            int val = 0;
            if(ChkSafe(nx,ny)){
                for(int j = 0; j < dx.Length; j++){
                    int tx = nx + dx[j];
                    int ty = ny + dy[j];
                    if(ChkSafe(tx, ty)){
                        val++;
                    }
                }

                if(minVal > val){
                    minVal = val;
                    minIdx = i;
                }
            }
        }
        nx = x + dx[minIdx];
        ny = y + dy[minIdx];
        
        //위에서 이미 체크했기 때문에 또 ChkSafe를 해줄 필요 없다.
        chess[x,y] = count;
        //++count는 count 자체에 +1더하고 대입하는거고 count+1은 그냥 count에 1을 더한 식이다.
        //엄연히 다르므로 헷갈리지말자
        if(KnightTour(nx,ny,count+1)) return true;
        else chess[x,y] = 0;
        
        return false;
    }

    static bool ChkSafe(int x, int y)
    {
        if ((0 <= x && x < chess.GetLength(0)) && (0 <= y && y < chess.GetLength(0)) && (chess[x,y] == 0)){
            return true;
        }
        return false;
    }
}