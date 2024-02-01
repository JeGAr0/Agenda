int[] array1 = new int[] { 1, 2, 3, 4, 5, 6 };

EliminarMantenintPosicio(array1, ref array1, 3);


    static void EliminarMantenintPosicio(int[] t, ref int nEl, int pos)
{
    if (pos >= 0 && pos < nEl)
    {
        for (int i = pos; i < nEl - 1; i++)
        {
            t[i] = t[i + 1];
        }
        nEl--;
    }
}