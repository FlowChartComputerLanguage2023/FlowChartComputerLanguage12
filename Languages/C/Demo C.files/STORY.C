//  /*  This is a simple guessing game to see if they can find out
//    that the story is made up as they go along.  Questions are
//    answered according to what they ask.  Just to keep them simi
////    honest the words of the questions are looked up in an ever
//    expanding table.  If less than 80% of the words are not in
//    the table then they are questioned about the question they
//    are asking.
//*/

// /*
//    The way the game works is that every question that is asked is
//    answered according to the number of words in the sentence.  Odd
//    is answered NO and even is answered Yes. (or last character in the
//    last word. ETC:)
//*/



#include <stdio.h>

// /****************************************************************/
void print(char string[])
{
printf("%s",string);
}
// /****************************************************************/
void input(char string[],int length)
{
gets(string);       /* needs to be changed to avoid to long a line */
}
// /****************************************************************/
// /****************************************************************/
// /****************************************************************/

main()
{
char buffer[255];
int kount;         // /* number of words in the sentence */
int i,j,k;
FILE *fp;


print("\nInstructions: ");
print("\n  ");
print("\n This is a game where I have a story and you try to guess");
print("\n it.  I will answer your questions Yes or No.  If I (Computer");
print("\n Program) have problems with your question then I will have ");
print("\n to go through some questions of my own to find associated ");
print("\n word meanings that I know.");
print("\n  ");
print("\n  When you want to quit then please use the Enter key to get");
print("\n  out of the questions.");
print("\n  ");
print("\n  To answer your question, I am playing by fixed rules So if you");
print("\n  are not careful with your questions then I will not seem to answer");
print("\n  the same way.  If you have problems then ask the question again in");
print("\n  a differant way. (Being a computer program I am very picking about");
print("\n  the way things are worded.");
print("\n  ");
print("\n  ");
for(;;)     /* for ever loop until they quit. */
{
print("\nWhat is your question about the story (Enter to quit the game) ?");
print("\n");
input(buffer,255);
j = 0;      /* number of words in a sentencs */
for(i=0;buffer[i] >= ' ';i++)
    {
    if(     buffer[i] == 'A'
        ||  buffer[i] == 'E'
        ||  buffer[i] == 'I'
        ||  buffer[i] == 'O'
        ||  buffer[i] == 'U'
        ||  buffer[i] == 'a'
        ||  buffer[i] == 'e'
        ||  buffer[i] == 'i'
        ||  buffer[i] == 'o'
        ||  buffer[i] == 'u'
        ){
        j = 3;    // /* one more word */
        }
    else if (buffer[i] >= 'A' && buffer[i] <= 'z')
        j = 1;
    else if ( buffer[i] == '?')
        j = 2;
    }
if(j == 0)
    exit(1);
 if(    strstr(buffer,"is "  ) == NULL
     && strstr(buffer,"do "  ) == NULL
     && strstr(buffer,"does ") == NULL
     && strstr(buffer,"are " ) == NULL
     && strstr(buffer,"will ") == NULL
     && strstr(buffer,"can " ) == NULL)print("\nI am unable to  answer that question!");
else if ( j == 2)
    print("\n You must not end with a ?");
else if(j == 3)
    {
    fp = fopen("story.dat","a");
    if(fp != NULL){
        fprintf(fp,"Yes %s\n",buffer);
        fclose(fp);
        }
    print("\nYes");
    }
else if ( j == 1)
    {
    fp = fopen("story.dat","a");
    if(fp != NULL){
        fprintf(fp,"No %s\n",buffer);
        fclose(fp);
        }
    print("\nNo");
    }
}
}
