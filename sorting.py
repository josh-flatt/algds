
def quickSort(A: list, lo: int, hi: int):
    """
    partitions the array into two, and then sorts each of those partitions.
    """
    if lo >= hi or lo < 0:
        return

    pivot_index = partition(A, lo, hi)

    quickSort(A, lo, pivot_index - 1)
    quickSort(A, pivot_index + 1, hi)



def partition(A: list, lo: int, hi: int):
    """
    Partitions the portion of the list from lo to hi into left
    and right subarrays where the left side <= pivot; right side > pivot.
    Returns the pivot index.
    """
    pivot = A[hi]

    i = lo - 1
    for j in range(lo, hi):
        if A[j] <= pivot:
            i += 1
            temp = A[i]
            A[i] = A[j]
            A[j] = temp
    
    i += 1
    A[hi] = A[i]
    A[i] = pivot
    return i

if __name__ == "__main__":
    trySort = [2, 6, 14, 3, 7, 4]
    print(trySort)
    quickSort(trySort, 0, len(trySort)-1)
    print(trySort)
    print()
    trySort2 = [6, 7, 89, 12, 83, 65, 5, 28]
    print(trySort2)
    quickSort(trySort2, 0, len(trySort2)-1)
