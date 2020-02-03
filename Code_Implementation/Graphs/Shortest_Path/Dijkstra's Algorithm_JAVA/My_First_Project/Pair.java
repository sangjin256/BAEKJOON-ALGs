import java.util.*;

class Pair implements Comparable<Pair> {
	public int index;
	public int distance;
	
	Pair(int index, int distance){
		this.index = index;
		this.distance = distance;
	}
	
	public int compareTo(Pair p) {
		if(distance > p.distance) return 1;
		else if(distance < p.distance) return -1;
		else return 0;
	}
}
