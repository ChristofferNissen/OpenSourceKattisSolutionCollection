#include <stdio.h>

int inRange(int x, int y, int ti, int tj)
{
    if (ti < 0)
    {
        return 0;
    }
    if (tj < 0)
    {
        return 0;
    }

    if (ti >= x)
    {
        return 0;
    }
    if (tj >= y)
    {
        return 0;
    }

    return 1;
}

int find(int disjoint[], int a)
{
    // default case
    if(disjoint[a] == -1)
    {
        return a;
    }

    disjoint[a] = find(disjoint, disjoint[a]);
    return disjoint[a];
}

void join(int disjoint[], int a, int b)
{
    a = find(disjoint, a);
    b = find(disjoint, b);

    if (a == b)
        return;

    disjoint[a] = b;
}

int main()
{
    int d1, d2;
    scanf("%d %d", &d1, &d2);

    int field[d1][d2];
    for(int i = 0; i < d1; i++)
    {
        char arr[d2];
        scanf("%s", &arr);
        for(int y = 0; y < d2; y++)
        {
            field[i][y] = arr[y] - '0';
        }
    }

    // now field should be all set

    // create array to hold group data, and init group numbers to -1
    int len = d1*d2;
    int disjoint[len];
    for (int i = 0; i < len; i++)
        disjoint[i] = -1;
    
    // add each in the array to Union Find (two should be merged, if the value of the field are the same)
    for (int i = 0; i < d1; i++)
    {
        for(int j = 0; j < d2; j++)
        {
            int ti, tj;

            ti = i + 1;
            tj = j;
            if (inRange(d1, d2, ti, tj) && field[i][j] == field[ti][tj])
            {
                join(disjoint, i * d2 + j, ti * d2 + tj);
            }

            ti = i;
            tj = j + 1;
            if (inRange(d1, d2, ti, tj) && field[i][j] == field[ti][tj])
            {
                join(disjoint, i * d2 + j, ti * d2 + tj);
            }

        }
    }

    // parse number of paths, and paths
    int numberOfPaths;
    scanf("%d", &numberOfPaths);
    
    int pathLines[numberOfPaths][4];
    for(int i = 0; i < numberOfPaths; i++)
    {
        scanf("%d %d %d %d", &pathLines[i][0], &pathLines[i][1], 
        &pathLines[i][2], &pathLines[i][3]);
    }

    // process paths
    for(int i = 0; i < numberOfPaths; i++)
    {
        int r1, c1, r2, c2;
        r1 = pathLines[i][0] - 1;
        c1 = pathLines[i][1] - 1;
        r2 = pathLines[i][2] - 1;
        c2 = pathLines[i][3] - 1;
        if (find(disjoint, r1*d2+c1) == find(disjoint, r2*d2+c2))
        {
            if (field[r1][c1] == 1)
            {
                printf("decimal\n");
            }
            else
            {
                printf("binary\n");
            }
        }
        else
        {
            printf("neither\n");
        }
    }
    
    return 0;

}
