﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRPG
{
    public class AsciiSprite
    {
        public StringBuilder sb;

        public void SpriteRender() {
            System.Console.Write(sb);
        }

    }

    public class S_Toriel : AsciiSprite
    {
        public S_Toriel() {
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

    public class S_Jery : AsciiSprite
    {
        public S_Jery() {
            sb = new StringBuilder();
            sb.Append("\t\t\t               :.                \r\n");
            sb.Append("\t\t\t           @*:%@%.               \r\n");
            sb.Append("\t\t\t           +@@@@@@@              \r\n");
            sb.Append("\t\t\t           @@@@@@@@              \r\n");
            sb.Append("\t\t\t          :@@@@@@@@:           : \r\n");
            sb.Append("\t\t\t    .@@@@@@@@@@@@@@@@@@@@:   :@+ \r\n");
            sb.Append("\t\t\t:@  =@@@@@@@@@@@@@@@@@@@@*  .@   \r\n");
            sb.Append("\t\t\t  =%%#  o  =:-=  % + o  -@%@@.   \r\n");
            sb.Append("\t\t\t        =@ *#   .*.-%            \r\n");
            sb.Append("\t\t\t                                 ");
        }
    }

    public class S_Wimson : AsciiSprite { 

        public S_Wimson() {
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

    public class S_GreatDog : AsciiSprite
    {
        public S_GreatDog()
        {
            sb = new StringBuilder();
            sb.Append("\t\t\t            #  #     +#   \r\n");
            sb.Append("\t\t\t           #. .-    #. #  \r\n");
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

    public class S_Flowey : AsciiSprite
    {
        public S_Flowey()
        {
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

    public class S_PapyRus : AsciiSprite { 
        
        public S_PapyRus()
        {
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

    public class S_Sanz : AsciiSprite
    {
        public S_Sanz()
        {
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

    public class S_Undyne : AsciiSprite
    {
        public S_Undyne()
        {
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
