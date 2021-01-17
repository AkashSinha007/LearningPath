/*
Reverse the array
*/
/*
https://www.geeksforgeeks.org/write-a-program-to-reverse-an-array-or-string/
*/

#include<iostream>
using namespace std;

void printArray(int arr[], int size)
{
    for(int i=0;i<size;i++)
    {
        cout<<arr[i]<<" ";
        
    }
    cout<<endl;
}

void reverseArray(int arr[],int start ,int end)
{
    if(start>=end)
        return;

    int temp=arr[start];
    arr[start]=arr[end];
    arr[end]=temp;
    reverseArray(arr,start+1,end-1);
}

int main()
{
    int a[] = {1, 2, 3, 4, 5, 6};
    int n= sizeof(a)/sizeof(a[0]);

    printArray(a, n);

    reverseArray(a,0,n-1);

    printArray(a, n);
    return 0;
}