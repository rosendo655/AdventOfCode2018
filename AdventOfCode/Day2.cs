using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    class Day2
    {
        static string regexLine = ".*\n";
        static Regex regex = new Regex(regexLine);
        

        public static void Part1()
        {
            int contadorPares = 0;
            int contadorTercias = 0;
            var lines = new Regex(regexLine).Matches(input);
            foreach (Match match in lines)
            {
                string inputLine = match.Value;
                var groups = inputLine.GroupBy(c => c);
                bool isPar = false;
                bool isTercia = false;
                foreach (var group in groups)
                {
                    if (group.Count() == 2) isPar = true;
                    if (group.Count() == 3) isTercia = true;
                }
                contadorPares += isPar ? 1 : 0;
                contadorTercias += isTercia ? 1 : 0;
            }
            Console.WriteLine(contadorTercias * contadorPares);
            Console.ReadKey();
        }

        public static void Part2()
        {
            var matches = regex.Matches(input);
            var lines = matches.ToList().Select(s => s.Value.Replace("\r","").Replace("\n","")).ToList();
            List<string> single = new List<string>();
            foreach(string lineA in lines)
            {
                foreach (string lineB in lines)
                {
                    if(lineA != lineB)
                    {
                        if (Compare(lineA, lineB) == 1)
                        {
                            single.Add($"{lineA}\n{lineB}\n{Difference(lineA,lineB)}\n\n");
                        }
                    }
                }
            }

            foreach(string s in single)
            {
                Console.WriteLine(s);
            }
            Console.ReadLine();
        }

        public static int Compare(string a , string b)
        {
            int count = 0;
            for(int  i = 0; i < a.Length; i++)
            {
                count += (a[i] == b[i]) ? 0 : 1;
            }
            return count;
        }

        public static string Difference(string a,string b)
        {
            return new string(b.Where(c => a.Contains(c)).ToArray());
        }

        static string input = @"bvhfawknyoqsudzrpgslecmtkj
bpufawcnyoqxldzrpgsleimtkj
bvhfawcnyoqxqdzrplsleimtkf
bvhoagcnyoqxudzrpgsleixtkj
bxvfgwcnyoqxudzrpgsleimtkj
bvqfawcngoqxudzrpgsleiktkj
bvhfawcnmoqxuyzrpgsleimtkp
bvheawcnyomxsdzrpgsleimtkj
bcdfawcnyoqxudzrpgsyeimtkj
bvhpawcnyoqxudzrpgsteimtkz
bxhfawcnyozxudzrpgsleimtoj
bvhfdwcnyozxudzrposleimtkj
bvpfawcnyotxudzrpgsleimtkq
bvhfpwccyoqxudzrpgslkimtkj
bvhfawcnyoqxudirpgsreimtsj
bvhfawcnyoqxudzppgbleemtkj
bvhzawcnyoqxudqrpgslvimtkj
bvhfawclyoqxudirpgsleimtka
bvhgawfnyoqxudzrpguleimtkj
bvhfazcnytqxudzrpgslvimtkj
bvhfawcnygxxudzrpgjleimtkj
bxhfawcnyoqxudzipgsleimtxj
bvhptwcnyoqxudzrpgsleimtmj
bzhfawcgyooxudzrpgsleimtkj
bvhjlwcnyokxudzrpgsleimtkj
bvhfawcnyoqxudbrmgslesmtkj
bvhfawcnysixudzwpgsleimtkj
bvhflwcnymqxxdzrpgsleimtkj
bvifawcnyoyxudzrpgsleimtvj
bvhfawcnyofxudlrpgsheimtkj
bvhbawcmyoqxudzrpggleimtkj
bhhxgwcnyoqxudzrpgsleimtkj
bvhfawgnyoqxbdzrpgsleimfkj
bvhfawcnyoqxudcrngsleimykj
bvhfawcnyofxudzrpgslebgtkj
bvhfaocnybqxudzapgsleimtkj
bvhxawcnyodxudzrpfsleimtkj
bchfawcnyoqxudrrtgsleimtkj
bvhfawcqyoqxudzdpgsltimtkj
bvhfawknyoqxudzrpnsleimtbj
cihfawcnyoqxudirpgsleimtkj
bvlfawpnyoqxudzrpgslgimtkj
bulfawcnyoqbudzrpgsleimtkj
bvhfajcnyoqkudzrpgsoeimtkj
bvhrakcnyoqxudzrpgsleimjkj
bvbftwcnyoqxuvzrpgsleimtkj
bvhfhwcnyoqxudzrpgslelmtbj
bvhyawcntoqxudzrpgsleimtuj
xvhuawcnyoqxuqzrpgsleimtkj
pvhfawcnyoqxudzdpglleimtkj
bvhfawsnyoqxudzrpgvlefmtkj
bvhfawcnyoqxudzrpgepeiwtkj
bvhfawcnyoqxudzrphsleittkr
dvhfawcnyoqxudzrpkslzimtkj
bvhfawpnyoqxudzrpgmlcimtkj
bvhsawcnyzqxudzrpgsaeimtkj
bdhfawcnyoqxudzrpasleiwtkj
bvhfawbnyoqxpdbrpgsleimtkj
mvhfawwnyoqxujzrpgsleimtkj
bvafawcnyoyxudzrpgsleidtkj
bvhyawcnyoqxudztpgzleimtkj
besfawcnyoqxudzrpgsleimdkj
bvhfawcnyoqxudrrpgsjeimjkj
xvhfkwcnyoqxudzcpgsleimtkj
bvhfawcnyeqdudzrpgzleimtkj
bvhfuwcnybqxudzrpgsleimttj
lvhfawcnyoqhudzdpgsleimtkj
bvhfawcnyoqxudzrpgslevwtnj
bvhfadcnzoqxxdzrpgsleimtkj
bvsfawcnyoqxpdzrpgileimtkj
bzhfaycnyoqxudzrpgsxeimtkj
bwhfdwcnyoqxudzrpgsleimtkz
bvhfawcnyoqxudzrpgsjlimtkm
bvhfawcnyoqxudsrwgsleimtlj
bbhfalynyoqxudzrpgsleimtkj
bvhfawcnyeqxudzrpglleimtkr
bvhfawnnboqxurzrpgsleimtkj
yvhfawcnyoqxudzrpgslzimtpj
bvhfjwcnyoqxqdxrpgsleimtkj
bthfawcnyoqfudzrpgslhimtkj
bvhfawchuoqxudzqpgsleimtkj
bvhfawcndoqxudzrugsleimrkj
bvhfawcnnoqxjdzrpgsleidtkj
bvhpawcnyoqkudzrpgsleimtzj
bvhfaiinyoqxudzopgsleimtkj
bvhfawcnyxqxuizrigsleimtkj
bvnfawcnyoqxudzqpgsleimbkj
bvnfawcnyoeyudzrpgsleimtkj
bvhfawcnyoqxudarpgsieimtoj
bthcawcnyoqxudlrpgsleimtkj
bvhfnwcnyozxudzrpgsleomtkj
bpwfawcnyoqxudzrpgskeimtkj
bvhfapcnyoqxudnrpgsxeimtkj
bvhfdwcnyoqxubzrxgsleimtkj
fvhfawcnyoqxjdzrpgsleirtkj
bvhfawcneoqxudzrvzsleimtkj
bvhaawcnyoqxudzrpgsleimtex
bvhfawcnyojxudvrpgsleimckj
bvlfawcnyoqxddzrpgsleimtko
bvhfawclfoqxudzrpgsleiktkj
bvhfawciyobxudzrpgkleimtkj
bvhfpwcnyoqxudzrpgsqeimtkd
bvhyawcnyyqxudzrkgsleimtkj
bvhfawcncoqxudzrphsaeimtkj
bvhfawmnyoqxudzrpgifeimtkj
bvhfawcjyoqxudzjpgszeimtkj
bohfawcnwoqxudzrpgsleimwkj
bvhfaucnyoqxudzrpgfluimtkj
bvhfawlnyoqgudzrpgwleimtkj
bmhfawcnyoqxndzrpgsleymtkj
bvhfawcngoqxudzrpzxleimtkj
bihfawcnyoqxudrrpgsleimokj
lvhfawcnylqxudzrpgsleintkj
bvhfawcnyoqvugzrqgsleimtkj
bvhfawcnyoqxudzgpgslqimtij
bvhfawcnyoqludzrpgslnimtcj
hvhfawcnyolxudzrpgsmeimtkj
nvhfawcdkoqxudzrpgsleimtkj
bvhfawcnyoqxkdzrggsneimtkj
bvhfawnnyoqxudzrpgqleibtkj
bvhfawyuyoqxudzrhgsleimtkj
wvhfbwcnyoqxtdzrpgsleimtkj
bvhfawcnyoqxedzzpgoleimtkj
bvhfawcnioqxunzrpgsleimtnj
bvhfawctyoqxudzrpgsldkmtkj
bvhfawcnyonxudzrpgsleitpkj
bvefawcnyoqaudzhpgsleimtkj
bvhfawcnyxqxudzrpgslelmbkj
bvhfamrnyoqxudzrpgsleimgkj
bvhfaqcnyoqxudzrpgsaeimekj
bvhfawcnyoqcidzrpgsleimvkj
bvhfawcnnorxudzrpgsmeimtkj
bvroawcnyoqxudzrpgsleiwtkj
bvhfwwcnyoqxudzrpaslewmtkj
bvsfawcnyoqxudzcpgszeimtkj
bkhfmwcnyoqjudzrpgsleimtkj
bvtfawcnyoqxudzrcgslecmtkj
bvhfawcnypzxudzrpgsleimtkv
bvhfawcnyoqzudzrfgtleimtkj
bvhpawcnyoqxudhrpgsleimtko
tvhfawcnyoqxudzxpfsleimtkj
bvhfawccyofxudzrpqsleimtkj
bvnfawtnyoqxuzzrpgsleimtkj
bvhfamcnuwqxudzrpgsleimtkj
bvhfawcfyoqxudjrpgsleimrkj
bvhpalcnyoqxudzrpgslexmtkj
bvhfawcnjsqxudzlpgsleimtkj
bvhfafcnioqxydzrpgsleimtkj
bvzfawcnyxqxudzgpgsleimtkj
bvhzawcnyoqxudzrpgslewctkj
bvhiawcnhoqrudzrpgsleimtkj
bvhfawcnyoqxuszrggslenmtkj
bvhfowcnyoqxudzrptseeimtkj
behfawfnyoqxudzrpgsleimlkj
lvhfawcnyoqxudsrpgvleimtkj
bvhfawnnyaqxudzrpgsqeimtkj
lvhfawcnfoqxvdzrpgsleimtkj
svhxawcnyoqxudzrpqsleimtkj
bvhfawqnfoqxudzrpgsleimkkj
bvhfafcnyoqcudzrpgsleimtcj
bvhfyfcntoqxudzrpgsleimtkj
bvhfpwcnyoqxudzrpgsleimumj
bvhfawccyoqxudzrqgrleimtkj
bvhfawqnyoqxudzbpgsleimkkj
bvhflwcnyoqxudzrpxsleemtkj
bvhfawcnyoqxuezrpgslehrtkj
bvhfawceyoqxudzrpgsleimswj
bvhfawcncohgudzrpgsleimtkj
bahfawcnyoqxgdzrpgsleamtkj
yvhfawcnyoqxudzrppslrimtkj
fvhfawcmyoqxudzrpgskeimtkj
bvylawsnyoqxudzrpgsleimtkj
bvhfswcnyyqxedzrpgsleimtkj
fvrfawcnyoqxudzrpgzleimtkj
bvhfawcnyoqxuvzrpgslermtks
bvhkawccyoqxudzcpgsleimtkj
bvhfaobnyoqxudzrprsleimtkj
bvbfawcnyoqxudirpgsleimhkj
bvhfawcnyoqxudzvpgsueimtgj
bvhxawcnyoqxudzrpgsleimtgi
svhfawcjyoqxuszrpgsleimtkj
bvnfawcnyoeyudzrpgsldimtkj
bvhfawcnyoqxuhzrpgsleimcki
bvhfvwcnyoqxudzizgsleimtkj
bvhfapznyohxudzrpgsleimtkj
bvhfaelnyosxudzrpgsleimtkj
xvhfawcnmoqxuhzrpgsleimtkj
bjhfawcnyaqxutzrpgsleimtkj
bvhfawcnyohxudzrpgslgnmtkj
bvhfawcnyoqxudzrppsreimtkx
fvhfapcnyoqyudzrpgsleimtkj
qvhfafcnyoqxudorpgsleimtkj
bvhfawcnyoqxedzrwgsleimtvj
bvhfawgnyoqxudzupgqleimtkj
bvhfowctyoqxudzrpgbleimtkj
bvhwawcnyoqxudzapgslvimtkj
bvhfadcnyoqxudzrugsleimtuj
bvhfawcnyosxudzlpgsleamtkj
bvhfawcnywqxuqzrpgsloimtkj
bvhfawcnyoqxumzrpgvlfimtkj
bvhfawcgyoqxbdzrpgsleomtkj
bvhfahcnyoqwudzrfgsleimtkj
gvbfawcnyrqxudzrpgsleimtkj
svhfawcnyoqxudlrpgsleimtkx
avhfafcnyoqxuhzrpgsleimtkj
bvhfawcsyoqxuazrpgsleimtej
bvofawcnyoqxudzrpgsteimtkf
bvhfajcnyoqxudzqpgszeimtkj
bvhfawcsyoqxudzrmgsleiktkj
mvhfawcnyoqxudzrpgkluimtkj
bvhfawcnhoqxudzrpgslwhmtkj
bmhaawsnyoqxudzrpgsleimtkj
bvhfawcnyoqxudzhpgsleimhyj
bvhfxwcnyoqxsdzypgsleimtkj
bvhpawcyyoqxuczrpgsleimtkj
bvomawcnyovxudzrpgsleimtkj
bvhfawcnjvqxudzrpgsleimtkt
nvhfawcnyqqxudzrpgsleittkj
bvhiawcnyzqxudzrpysleimtkj
bvhdawcnyoqxukzrpgsleimtuj
bvhfawcnyyxxudzrpgslzimtkj
hvhfawcnyoqxudzupgslemmtkj
byhfawknyoqxudzrpgsleimtkb
bvhfawcnyoqxudzrpasleihakj
bvafahcnyaqxudzrpgsleimtkj
bkhfawcnyoqxudzrpgllepmtkj
bghfawcnycqxuzzrpgsleimtkj
bvhfawcnyoqxudzrbgeleimtkl
bvhfascnyoqgudzrpgsveimtkj
bvhfawnnyoqxudzrpgsleimtdl
bvhqawcnyoqxudzrpgsleimgrj
bvhsawdwyoqxudzrpgsleimtkj
bvhfawcnyoqxudzrpgaleipttj
bvhfawcnrlqxudzrbgsleimtkj
bvhfdwcnyoqxudzqpcsleimtkj
bvhfawcnyoqxudzopgslexmokj
bvhfawcoyoqxudzrpghlewmtkj
bvhfozcnykqxudzrpgsleimtkj
bvhfawcnyoqxuvzrpgslrimtkr
bvhfrncnyoqrudzrpgsleimtkj
bvhfawcnyocxuizrpgslefmtkj
bvhfawywyoqxudzrpgsleimxkj
bvhfawcnyoqxugzrpgslrimtij
bvtfawcnyoqxudzcpgsleimtfj
bvhfawcnyoqxuzzspgsleimtkz
bvhfawcnzoqxvdzrpgslsimtkj
bvhfzwcnyoqxudzrpgslenmhkj
bvhfkccnyoqxudzrpgzleimtkj
bvhfawcnyoqzudzrpgslhimwkj
bzhfawvnyooxudzrpgsleimtkj
";
    }
}
