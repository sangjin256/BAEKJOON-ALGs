//두 플레이어가 번갈아 가며 게임을 진행하고, 상대방이 어떤 움직임을 택하더라도 항상 이길
//수 있는 전략이 있는 경우, 그러한 전략을 찾는 것이 목표
//여기서는 막대기 n개로 이루어진 더미로 진행하는 게임.
//두 플레이어가 번갈아 가며 진행하며, 각 플레이어는 한 개 이상 세 개 이하의 막대기를 더미에서
//제거해야 함. 마지막 막대기를 제거하는 사람이 승리

//게임 분석 : k가 4로 나누어떨어지면 k는 패배 상태이고, 그렇지 않다면 승리 상태가 됨
//따라서 최적의 방법은 더미에 있는 막대기의 개수가 항상 4의 배수가 되도록 막대기를 가져감
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Lecture 
{
    enum States {WiningState, LosingState};
    [Flags]
    enum Players {p1 = 0, p2 = -1};
	public static void Main(string[] args) {
        int n = int.Parse(Console.ReadLine());
        //n이 4의 배수이면 패배상태이고 그 외에는 전부 승리상태이다.
        States state = States.WiningState;
        Players player = Players.p1;
		if(n%4==0) state = States.LosingState;

        while(n > 0){
            Console.WriteLine($"{player.ToString()} 차례.");
            Console.WriteLine($"남은 막대기 {n}개\n현재상태 : {state.ToString()}");
            Console.WriteLine("가져갈 막대기의 개수를 고르시오(1~3) : ");
            int temp = int.Parse(Console.ReadLine());
            n = n-temp;
            if(n%4==0) state = States.LosingState;
            else state = States.WiningState;
            //0의 보수는 -1
            player = ~player;
        }

        Console.WriteLine($"승자 : {~player}");
    }
}