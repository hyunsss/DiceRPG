using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRPG
{
    public class Monster
    {
        protected StringBuilder sb;
        protected int Hp;
        protected int FullHp;
        protected int Damage;
    }

    public class Toriel : Monster
    {
        public Toriel()
        {
            Hp = 500;
            FullHp = 500;
            Damage = 30;
            sb = new StringBuilder();
            sb.Append("\t\t\t                        .-         ..                        \r\n");
            sb.Append("\t\t\t                       #.--.------.+.#.                      \r\n");
            sb.Append("\t\t\t                      .#- #.      --.#-                      \r\n");
            sb.Append("\t\t\t                    .-.  .---.  .--.   --                    \r\n");
            sb.Append("\t\t\t                   .#  #.-###.  -#++.#. .#                   \r\n");
            sb.Append("\t\t\t                  .#   #.#-#+.  ++#++#.  --                  \r\n");
            sb.Append("\t\t\t                   #   ##  .     .. -#.  --                  \r\n");
            sb.Append("\t\t\t                  .#   .#-  .. ..  .#-   --                  \r\n");
            sb.Append("\t\t\t                   .#   ##+.-....-.##-   #                   \r\n");
            sb.Append("\t\t\t                -+-##.  .###-+++-+###   +##-+.               \r\n");
            sb.Append("\t\t\t              -- .####++##############+####- .+              \r\n");
            sb.Append("\t\t\t             +-  +###++++###########++++####.  #.            \r\n");
            sb.Append("\t\t\t            -+   ###-##-##############+##-##-   #            \r\n");
            sb.Append("\t\t\t           .+   .###-####  .#- .##  -####-##+   --           \r\n");
            sb.Append("\t\t\t           --   ###+#######+##+#########-####.   +.          \r\n");
            sb.Append("\t\t\t          .+.   ###-###################+#####.   --          \r\n");
            sb.Append("\t\t\t         .#    .###-#######.-###+.-###+######-    -+         \r\n");
            sb.Append("\t\t\t         #     +-##-####+#####-+############++     +-        \r\n");
            sb.Append("\t\t\t       .+.     +-###########################++.     --       \r\n");
            sb.Append("\t\t\t       #.     .+.##########+################++.      +.      \r\n");
            sb.Append("\t\t\t      +-      .-.#+########################+---       #      \r\n");
            sb.Append("\t\t\t      .#-     .-.#+########################+---     -#-      \r\n");
            sb.Append("\t\t\t      +--#.   .-.#+########################+---    ++ #.     \r\n");
            sb.Append("\t\t\t     +.  .#+  .-.#+########################+---  .#+   +-    \r\n");
            sb.Append("\t\t\t    .+  ---#- .-.#+########################+---  ##.+. --    \r\n");
            sb.Append("\t\t\t     .+-+#- .-+- #+########################+-.+-- .##-+-     \r\n");
            sb.Append("\t\t\t                 #+########################+-                \r\n");
            sb.Append("\t\t\t                -+##########################+.               \r\n");
            sb.Append("\t\t\t                #-##########################+.               \r\n");
            sb.Append("\t\t\t                 .+--+#######+--+######+--+-                 \r\n");
            sb.Append("\t\t\t                    -########.  #########.                   \r\n");
            sb.Append("\t\t\t                +##+-       .- -+        -##+.               \r\n");
            sb.Append("\t\t\t              --.  .       .-- .--.       . ..+              \r\n");
            sb.Append("\t\t\t              --#..# -----.       .----+.-+ #+-              \r\n");
            sb.Append("\t\t\t                                                             ");

        }
    }
    public class Jery : Monster
    {
        public Jery() {
            Hp = 500;
            FullHp = 500;
            Damage = 30;
            sb = new StringBuilder();
            sb.Append("\t\t\t               :.                \r\n");
            sb.Append("\t\t\t           @*:%@%.               \r\n");
            sb.Append("\t\t\t           +@@@@@@@              \r\n");
            sb.Append("\t\t\t           @@@@@@@@              \r\n");
            sb.Append("\t\t\t          :@@@@@@@@:           : \r\n");
            sb.Append("\t\t\t    .@@@@@@@@@@@@@@@@@@@@:   :@+ \r\n");
            sb.Append("\t\t\t:@  =@@@@@@@@@@@@@@@@@@@@*  .@   \r\n");
            sb.Append("\t\t\t  =%%#    =:-=  % +     -@%@@.   \r\n");
            sb.Append("\t\t\t        =@ *#   .*.-%            \r\n");
            sb.Append("\t\t\t                                 ");
        }
    }
    public class Wimson : Monster
    {
        public Wimson()
        {
            Hp = 500;
            FullHp = 500;
            Damage = 30;
            sb = new StringBuilder();
            sb.Append("\t\t\t         ::          :       \r\n");
            sb.Append("\t\t\t       .@+ @.       *:#      \r\n");
            sb.Append("\t\t\t           :+:@@@@@+= @@     \r\n");
            sb.Append("\t\t\t           =@@@@@@@@*        \r\n");
            sb.Append("\t\t\t         .@@=@@@@*+@@        \r\n");
            sb.Append("\t\t\t         *@@@@==@@@@@@       \r\n");
            sb.Append("\t\t\t      :@ *@@@:  :@@@@@       \r\n");
            sb.Append("\t\t\t   :+%+#:@@@@@@@@@@@@@=@     \r\n");
            sb.Append("\t\t\t =@#%@%:@@%.:@@* *@@@.@@#.   \r\n");
            sb.Append("\t\t\t  ..  +*@@@@@@@@@@#@@::@*#:  \r\n");
            sb.Append("\t\t\t       @@@@@@@@@@@@@#   :-:  \r\n");
            sb.Append("\t\t\t          .  .  :  :         \r\n");
            sb.Append("\t\t\t            %:  *:           \r\n");
            sb.Append("\t\t\t          *@+   +@@.         \r\n");
            sb.Append("\t\t\t                             ");
        }
    }
    public class GreatDog : Monster
    {
        public GreatDog()
        {
            Hp = 500;
            FullHp = 500;
            Damage = 30;
            sb = new StringBuilder();
            sb.Append("\t\t\t            #  #     +#   \r\n");
            sb.Append("\t\t\t           #...-    #. #  \r\n");
            sb.Append("\t\t\t   #+--###+     ###+-.--  \r\n");
            sb.Append("\t\t\t #..    +#       -#+##-## \r\n");
            sb.Append("\t\t\t +      .###+--+### -#+- #\r\n");
            sb.Append("\t\t\t #      #  -####- -+##+#+#\r\n");
            sb.Append("\t\t\t+ -++++#     .    .-##+#+ \r\n");
            sb.Append("\t\t\t#    .++#####+#####-##+# +\r\n");
            sb.Append("\t\t\t--##################+  .+#\r\n");
            sb.Append("\t\t\t#..---###+-# -.-+.#.-   -+\r\n");
            sb.Append("\t\t\t -####-##-######+.##+ .+# \r\n");
            sb.Append("\t\t\t #+-++..####+  +-. # #+   \r\n");
            sb.Append("\t\t\t #    --#---####-.#  #+   \r\n");
            sb.Append("\t\t\t  +...-# #+## ##-+   #+   \r\n");
            sb.Append("\t\t\t        #. .# +. +   #+   ");
        }
    }
    public class Flowey : Monster
    {
        public Flowey() {
            Hp = 500;
            FullHp = 500;
            Damage = 30;
            sb = new StringBuilder();
            sb.Append("\t\t\t                           \r\n ");
            sb.Append("\t\t\t       .:@@@.  :@@@.       \r\n ");
            sb.Append("\t\t\t      @@#  +****: :%@+     \r\n ");
            sb.Append("\t\t\t   @@@= %@@@*@@#@@@= @@@=  \r\n ");
            sb.Append("\t\t\t :@@@@.=@@@@.@@:@@@@ =@@@% \r\n ");
            sb.Append("\t\t\t   :@@@ @@%.==== @@+:@@@.  \r\n ");
            sb.Append("\t\t\t      @@ -@@@@@@@@..@#     \r\n ");
            sb.Append("\t\t\t    .@%@@@%==:===@@@%@@    \r\n ");
            sb.Append("\t\t\t      @@@=        %@@*     \r\n ");
            sb.Append("\t\t\t           -@@.            \r\n ");
            sb.Append("\t\t\t           @@:             \r\n ");
            sb.Append("\t\t\t            +@@            \r\n ");
            sb.Append("\t\t\t          . :@@% .         \r\n ");
            sb.Append("\t\t\t          +=%@@:@.         \r\n ");
            sb.Append("\t\t\t            ...            ");

        }
    }

    public class PapyRus : Monster
    {

        public PapyRus() {
            Hp = 500;
            FullHp = 500;
            Damage = 30;
            sb = new StringBuilder();
            sb.Append("\t\t\t          :::.             \r\n ");
            sb.Append("\t\t\t       :*%@@@@@=           \r\n ");
            sb.Append("\t\t\t       =@=@@@*@+           \r\n ");
            sb.Append("\t\t\t       .-@@@@%+.           \r\n ");
            sb.Append("\t\t\t     *%- ==+%+=-#@%=-.     \r\n ");
            sb.Append("\t\t\t  =*:-@@*=:-=*%%%@@@%#%*=::\r\n ");
            sb.Append("\t\t\t *@@%@@@@@@@@@@%@@@@%      \r\n ");
            sb.Append("\t\t\t :%@++@@@@@@@@@@:-%=       \r\n ");
            sb.Append("\t\t\t=@+      ...     *@        \r\n ");
            sb.Append("\t\t\t    . .%@=@.     =%        \r\n ");
            sb.Append("\t\t\t   *#%@@*=#=-:   +=        \r\n ");
            sb.Append("\t\t\t      .*@%@@%=   =#--=+*#@:\r\n ");
            sb.Append("\t\t\t      .%*   *@:  :+@@@@+:  \r\n ");
            sb.Append("\t\t\t    -::=:=#  ::*-    ..    \r\n ");
            sb.Append("\t\t\t     -@##@..#@@###         \r\n ");
            sb.Append("\t\t\t   .-+*@@@@   *@@%@@@%.    \r\n ");
            sb.Append("\t\t\t   *@@@@%+=    *#%@@@@-    ");
        }
    }
    public class Sanz : Monster
    {
        public Sanz()
        {
            Hp = 500;
            FullHp = 500;
            Damage = 30;
            sb = new StringBuilder();
            sb.Append("\t\t\t          ......          \r\n");
            sb.Append("\t\t\t      .+##########-       \r\n");
            sb.Append("\t\t\t     .##############.     \r\n");
            sb.Append("\t\t\t     -##--.####.--##.     \r\n");
            sb.Append("\t\t\t     .##-+-####-+-#+      \r\n");
            sb.Append("\t\t\t      +############-      \r\n");
            sb.Append("\t\t\t    .-+#####+#+####++-    \r\n");
            sb.Append("\t\t\t   .############++##+--   \r\n");
            sb.Append("\t\t\t  -- ..-##+###+++#---.+-  \r\n");
            sb.Append("\t\t\t --  -+-##+###+#-.-#-  -# \r\n");
            sb.Append("\t\t\t.#- .--..+#####+++.--.  # \r\n");
            sb.Append("\t\t\t  ++--   +######-  -+.-#- \r\n");
            sb.Append("\t\t\t   .-##--+++---++++#+--   \r\n");
            sb.Append("\t\t\t     -++-   -  .#- --     \r\n");
            sb.Append("\t\t\t    .-##.  .## .## --.    \r\n");
            sb.Append("\t\t\t    .+#+   #.#  +#..-.    \r\n");
            sb.Append("\t\t\t    .---++-- .-+##+-..    \r\n");
            sb.Append("\t\t\t   -#####-     ########.  \r\n");
            sb.Append("\t\t\t    ......     ........   ");

        }
    }
    public class Undyne : Monster
    {
        public Undyne()
        {
            Hp = 500;
            FullHp = 500;
            Damage = 30;
            sb = new StringBuilder();
            sb.Append("\t\t\t                          \r\n");
            sb.Append("\t\t\t      %@@@@@=  %@@        \r\n");
            sb.Append("\t\t\t   @@@@@@@@@%%-%@=* -     \r\n");
            sb.Append("\t\t\t  @@@       ==@:@ --      \r\n");
            sb.Append("\t\t\t @          : @*  %       \r\n");
            sb.Append("\t\t\t        ==@@%: :=.: =@@== \r\n");
            sb.Append("\t\t\t         +   .     =   =: \r\n");
            sb.Append("\t\t\t         %@* : . =  - *@  \r\n");
            sb.Append("\t\t\t         @@     :     @@= \r\n");
            sb.Append("\t\t\t        @@  %:*=*= @      \r\n");
            sb.Append("\t\t\t       .@@=% *:    -+ @@@ \r\n");
            sb.Append("\t\t\t       -@@  += -=*= = @@@ \r\n");
            sb.Append("\t\t\t       @%:  *. %@@@:--@@: \r\n");
            sb.Append("\t\t\t       %   # : *@ %.      \r\n");
            sb.Append("\t\t\t    *@           *#:      \r\n");
            sb.Append("\t\t\t   =:@       :@+@ @@      \r\n");
            sb.Append("\t\t\t   @         .-=+@@=      \r\n");
            sb.Append("\t\t\t              *@*@@       \r\n");
            sb.Append("\t\t\t            ++=    ++=    ");

        }
    }
}
