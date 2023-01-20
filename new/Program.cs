using System.Text;


string str = "what a wonderfull day today haha";
int count = 0;
for (int i = 0; i < str.Length; i++)  
{
    if (str[i] == 'a')
    {
        count++;
    }
}
Console.WriteLine(count);
