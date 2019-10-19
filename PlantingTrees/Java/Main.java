import java.util.ArrayList;
import java.util.Collections;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int N = scanner.nextInt();
        ArrayList<Integer>arrayList = new ArrayList<>();
        for (int i = 0; i < N; i++) {
            arrayList.add(scanner.nextInt());
        }
        arrayList.sort(Collections.reverseOrder());
        int max = 0;
        for (int i = 0; i < arrayList.size(); i++) {
            max = Math.max(max,arrayList.get(i) + (i + 1));
        }
        System.out.println(max + 1);
    }
}


