using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace _1122
{
    public partial class Form1 : Form
    {
        string[] Words =  // слова, которые будут загадываться.
            {
            "ABUSE", "ADULT", "AGENT", "ANGER", "APPLE", "AWARD", "BASIS", "BEACH", "BIRTH", "BLOCK", "BLOOD", "BOARD", "BRAIN", "BREAD", "BREAK", "BROWN", "BUYER", "CAUSE", "CHAIN", "CHAIR", "CHEST", "CHIEF", "CHILD", "CLAIM", "CLASS", "CLOCK", "COACH", "COAST", "COURT", "COVER", "CREAM", "CRIME", "CROSS", "CROWD", "CROWN", "CYCLE", "DANCE", "DEATH", "DEPTH", "DOUBT", "DRAFT", "DRAMA", "DREAM", "DRESS", "DRINK", "DRIVE", "EARTH", "ENEMY", "ENTRY", "ERROR", "EVENT", "FAITH", "FAULT", "FIELD", "FIGHT", "FINAL", "FLOOR", "FOCUS", "FORCE", "FRAME", "FRONT", "FRUIT", "GLASS", "GRASS", "GREEN", "GROUP", "GUIDE", "HEART", "HORSE", "HOTEL", "HOUSE", "IMAGE", "INDEX", "INPUT", "ISSUE", "JUDGE", "KNIFE", "LAURA", "LAYER", "LEVEL", "LEWIS", "LIGHT", "LIMIT", "LUNCH", "MAJOR", "MARCH", "MATCH", "METAL", "MODEL", "MONEY", "MONTH", "MOTOR", "MOUTH", "MUSIC", "NIGHT", "NOISE", "NORTH", "NOVEL", "NURSE", "OFFER", "ORDER", "OTHER", "OWNER", "PANEL", "PAPER", "PARTY", "PEACE", "PHASE", "PHONE", "PIECE", "PILOT", "PITCH", "PLACE", "PLANE", "PLANT", "PLATE", "POINT", "POUND", "POWER", "PRESS", "PRICE", "PRIDE", "PRIZE", "PROOF", "QUEEN", "RADIO", "RANGE", "RATIO", "REPLY", "RIGHT", "RIVER", "ROUND", "ROUTE", "RUGBY", "SCALE", "SCENE", "SCOPE", "SCORE", "SENSE", "SHAPE", "SHARE", "SHEEP", "SHEET", "SHIFT", "SHIRT", "SHOCK", "SIGHT", "SIMON", "SKILL", "SLEEP", "SMILE", "SMITH", "SMOKE", "SOUND", "SOUTH", "SPACE", "SPEED", "SPITE", "SPORT", "SQUAD", "STAFF", "STAGE", "START", "STATE", "STEAM", "STEEL", "STOCK", "STONE", "STORE", "STUDY", "STUFF", "STYLE", "SUGAR", "TABLE", "TASTE", "THEME", "THING", "TITLE", "TOTAL", "TOUCH", "TOWER", "TRACK", "TRADE", "TRAIN", "TREND", "TRIAL", "TRUST", "TRUTH", "UNCLE", "UNION", "UNITY", "VALUE", "VIDEO", "VISIT", "VOICE", "WASTE", "WATCH", "WATER", "WHILE", "WHITE", "WHOLE", "WOMAN", "WORLD", "YOUTH", "ADMIT", "ADOPT", "AGREE", "ALLOW", "ALTER", "APPLY", "ARGUE", "ARISE", "AVOID", "BEGIN", "BLAME", "BREAK", "BRING", "BUILD", "BURST", "CARRY", "CATCH", "CAUSE", "CHECK", "CLAIM", "CLEAN", "CLEAR", "CLIMB", "CLOSE", "COUNT", "COVER", "CROSS", "DANCE", "DOUBT", "DRINK", "DRIVE", "ENJOY", "ENTER", "EXIST", "FIGHT", "FOCUS", "FORCE", "GUESS", "IMPLY", "ISSUE", "JUDGE", "LAUGH", "LEARN", "LEAVE", "LIMIT", "MARRY", "MATCH", "OCCUR", "OFFER", "ORDER", "PHONE", "PLACE", "POINT", "PRESS", "PROVE", "RAISE", "REACH", "REFER", "RELAX", "SERVE", "SHALL", "SHARE", "SHIFT", "SHOOT", "SLEEP", "SOLVE", "SOUND", "SPEAK", "SPEND", "SPLIT", "STAND", "START", "STATE", "STICK", "STUDY", "TEACH", "THANK", "THINK", "THROW", "TOUCH", "TRAIN", "TREAT", "TRUST", "VISIT", "VOICE", "WASTE", "WATCH", "WORRY", "WOULD", "WRITE", "ABOVE", "ACUTE", "ALIVE", "ALONE", "ANGRY", "AWARE", "AWFUL", "BASIC", "BLACK", "BLIND", "BRAVE", "BRIEF", "BROAD", "BROWN", "CHEAP", "CHIEF", "CIVIL", "CLEAN", "CLEAR", "CLOSE", "CRAZY", "DAILY", "DIRTY", "EARLY", "EMPTY", "EQUAL", "EXACT", "EXTRA", "FAINT", "FALSE", "FIFTH", "FINAL", "FIRST", "FRESH", "FRONT", "FUNNY", "GIANT", "GRAND", "GREAT", "GREEN", "GROSS", "HAPPY", "HARSH", "HEAVY", "HUMAN", "IDEAL", "INNER", "JOINT", "LARGE", "LEGAL", "LEVEL", "LIGHT", "LOCAL", "LOOSE", "LUCKY", "MAGIC", "MAJOR", "MINOR", "MORAL", "NAKED", "NASTY", "NAVAL", "OTHER", "OUTER", "PLAIN", "PRIME", "PRIOR", "PROUD", "QUICK", "QUIET", "RAPID", "READY", "RIGHT", "ROMAN", "ROUGH", "ROUND", "ROYAL", "RURAL", "SHARP", "SHEER", "SHORT", "SILLY", "SIXTH", "SMALL", "SMART", "SOLID", "SORRY", "SPARE", "STEEP", "STILL", "SUPER", "SWEET", "THICK", "THIRD", "TIGHT", "TOTAL", "TOUGH", "UPPER", "UPSET", "URBAN", "USUAL", "VAGUE", "VALID", "VITAL", "WHITE", "WHOLE", "WRONG", "YOUNG"
            };

        string wordbasestring = Properties.Resources.wordbase;  // база всех англ. слов из 5 букв.
        Random rnd = new Random();   // объявили рандомайзер.
        int NumberRightWord;  // номер слова из массива Words[], которое будет загадано.
        string RightWord;   // загаданное слово.
        string YourWord;  //  слово, которое мы вводим, пытаясь угадать загаданное.
        int Etap = 1;  // этап игры - строка, в которой мы в данный момент угадываем.
        string[] bukva = new string[5];  // переменные букв правильного слова.
        int plus;  //  специальные переменные, нужны для того чтобы желтые буквы подсвечивались ровно в том количестве, в каком они встречаются во введенном слове.
        int minus;  // разность этих переменных и будет количество раз, которое будет подсвечиваться конкретная буква в слове.
        int UzheViigral;      
        TextBox PreviousTextBox;
        bool b = false;
        object curSender;



        public static InputLanguage GetLanguage(string language)  // Проверяем, какие есть языки в Windows. Это нужно, чтобы потом создать ограничение на вводимый язык.
        {
            language = language.ToLower();
            foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
            {
                if (lang.Culture.TwoLetterISOLanguageName == language)
                {
                    return lang;
                }
            }
            return null;
        }
        

        
        public Form1()
        {
            InitializeComponent();
            NumberRightWord = rnd.Next(0, 401);  // генерируем случайное число от 1 до 402.
            RightWord = Words[NumberRightWord];  // выбираем слово из массива.

            for(int i = 0; i < 5; i++)  // задаем переменные букв правильного слова.
            { 
                bukva[i] = RightWord.Substring(i, 1);
            }

            Console.WriteLine(RightWord);  // нужно при тестировании, чтобы мы знали, какое слово загадано.
        }



        private void button1_Click(object sender, EventArgs e)  // проверяем введенное слово на соответствие с загаданным.
        {
            YourWord = "";

            for (int i = 1; i < 6; i++)  // запоминаем введенное нами слово.
            {
                YourWord += Controls["textBox" + (i + (Etap - 1) * 5)].Text;
            }


            int quantityLettersInYourWord = 0;

            for (int i = 1; i < 6; i++)  // считаем количество букв во введенном слове.
            {
                if (Controls["textBox" + (i + (Etap - 1) * 5)].Text != "")
                {
                    quantityLettersInYourWord++;
                }
            }

            if (!wordbasestring.Contains(YourWord) || quantityLettersInYourWord != 5)  // проверяем, существует ли такое слово.
            {
                return;  // если такого слова не существует, то ничего не делаем.
            }
                      
            

                    //  СЕРЫЙ ЦВЕТ.

            for (int i = 1; i < 6; i++)  // Сразу ставим серый цвет всем буквам. Если что, потом перекрасим в другой цвет.
            {
                Controls["textBox" + (i + (Etap - 1) * 5)].BackColor = Color.FromArgb(152, 152, 152);
            }

            for (int i = 1; i < 6; i++)  // Меняем цвет кнопок клавиатуры на серый, если этой буквы нет в загаданном слове.
            {
                (Controls["btn" + Controls["textBox" + (i + (Etap - 1) * 5)].Text] as Button).BackColor = Color.FromArgb(152, 152, 152);  
                (Controls["btn" + Controls["textBox" + (i + (Etap - 1) * 5)].Text] as Button).ForeColor = Color.White;
            }
            

            
                    //  ЖЕЛТЫЙ ЦВЕТ.

                // 1-ая буква

            plus = 0;     
            for (int i = 1; i < 6; i++)  //  определяем переменную plus для 1-ой буквы.
            {
                if (Controls["textBox" + (1 + (Etap - 1) * 5)].Text == bukva[i - 1])
                {
                    plus++;
                }
            }
            

            minus = 0;
            for (int i = 1; i < 5; i++)  // определяем переменную minus для 1-ой буквы. расширенный minus (вычитая зеленые цвета впоследствии).
            {
                if (Controls["textBox" + (1 + (Etap - 1) * 5)].Text == Controls["textBox" + (1 + (Etap - 1) * 5 + i)].Text &&
                    Controls["textBox" + (1 + (Etap - 1) * 5 + i)].Text == bukva[i])
                {
                    minus++;
                }
            }
                                  

            if (plus > minus)   //  проверка, можно ли подсвечивать желтым (достаточно ли букв в слове).
            {
                Controls["textBox" + (1 + (Etap - 1) * 5)].BackColor = Color.FromArgb(216, 202, 5);

                if (!((Controls["btn" + Controls["textBox" + (1 + (Etap - 1) * 5)].Text] as Button).BackColor == Color.FromArgb(45, 188, 40)))
                {
                    (Controls["btn" + Controls["textBox" + (1 + (Etap - 1) * 5)].Text] as Button).BackColor = Color.FromArgb(216, 202, 5);
                    (Controls["btn" + Controls["textBox" + (1 + (Etap - 1) * 5)].Text] as Button).ForeColor = Color.White;
                }
            }
                        

                        
                // 2-ая буква

            plus = 0; 
            for (int i = 1; i < 6; i++)  // определяем переменную plus для 2-ой буквы.
            {
                if (Controls["textBox" + (2 + (Etap - 1) * 5)].Text == bukva[i - 1])
                {
                    plus++;
                }
            }
            

            minus = 0;

            for (int i = 1; i < 2; i++)  // определяем переменную minus для 2-ой буквы.
            {
                if (Controls["textBox" + (2 + (Etap - 1) * 5)].Text == Controls["textBox" + (2 + (Etap - 1) * 5 - i)].Text)
                {
                    minus++;
                }
            }


            for (int i = 1; i < 4; i++)  // определяем переменную minus для 2-ой буквы. расширенный minus (вычитая зеленые цвета впоследствии).
            {
                if (Controls["textBox" + (2 + (Etap - 1) * 5)].Text == Controls["textBox" + (2 + (Etap - 1) * 5 + i)].Text &&
                    Controls["textBox" + (2 + (Etap - 1) * 5 + i)].Text == bukva[i + 1])
                {
                    minus++;
                }
            }
            

            if (plus > minus)   //  проверка, можно ли подсвечивать желтым (достаточно ли букв в слове).
            {
                Controls["textBox" + (2 + (Etap - 1) * 5)].BackColor = Color.FromArgb(216, 202, 5);

                if (!((Controls["btn" + Controls["textBox" + (2 + (Etap - 1) * 5)].Text] as Button).BackColor == Color.FromArgb(45, 188, 40)))
                {
                    (Controls["btn" + Controls["textBox" + (2 + (Etap - 1) * 5)].Text] as Button).BackColor = Color.FromArgb(216, 202, 5);
                    (Controls["btn" + Controls["textBox" + (2 + (Etap - 1) * 5)].Text] as Button).ForeColor = Color.White;
                }
            }
                    




                // 3-ья буква


            plus = 0;  
            for (int i = 1; i < 6; i++)  //  определяем переменную plus для 3-ей буквы.
            {
                if (Controls["textBox" + (3 + (Etap - 1) * 5)].Text == bukva[i - 1])
                {
                    plus++;
                }
            }
            
            
            minus = 0;

            for (int i = 1; i < 3; i++)  // определяем переменную minus для 3-ей буквы. 
            {
                if (Controls["textBox" + (3 + (Etap - 1) * 5)].Text == Controls["textBox" + (3 + (Etap - 1) * 5 - i)].Text)
                {
                    minus++;
                }
            }

            for (int i = 1; i < 3; i++)  // определяем переменную minus для 3-ей буквы. расширенный minus (вычитая зеленые цвета впоследствии).
            {
                if (Controls["textBox" + (3 + (Etap - 1) * 5)].Text == Controls["textBox" + (3 + (Etap - 1) * 5 + i)].Text &&
                    Controls["textBox" + (3 + (Etap - 1) * 5 + i)].Text == bukva[i + 2])
                {
                    minus++;
                }
            }
                                                   
            
            if (plus > minus)   //  проверка, можно ли подсвечивать желтым (достаточно ли букв в слове).
            {
                Controls["textBox" + (3 + (Etap - 1) * 5)].BackColor = Color.FromArgb(216, 202, 5);

                if (!((Controls["btn" + Controls["textBox" + (3 + (Etap - 1) * 5)].Text] as Button).BackColor == Color.FromArgb(45, 188, 40)))
                {
                    (Controls["btn" + Controls["textBox" + (3 + (Etap - 1) * 5)].Text] as Button).BackColor = Color.FromArgb(216, 202, 5);
                    (Controls["btn" + Controls["textBox" + (3 + (Etap - 1) * 5)].Text] as Button).ForeColor = Color.White;
                }
            }
                   


                // 4-ая буква

            plus = 0;  
            for (int i = 1; i < 6; i++)  //  определяем переменную plus для 4-ой буквы.
            {
                if (Controls["textBox" + (4 + (Etap - 1) * 5)].Text == bukva[i - 1])
                {
                    plus++;
                }
            }
                                   
                                
            minus = 0;  

            for (int i = 1; i < 4; i++)  // определяем переменную minus для 4-ой буквы.
            {
                if (Controls["textBox" + (4 + (Etap - 1) * 5)].Text == Controls["textBox" + (4 + (Etap - 1) * 5 - i)].Text)
                {
                    minus++;
                }
            }

            for (int i = 1; i < 2; i++)  // определяем переменную minus для 4-ой буквы. расширенный minus (вычитая зеленые цвета впоследствии).
            {
                if (Controls["textBox" + (4 + (Etap - 1) * 5)].Text == Controls["textBox" + (4 + (Etap - 1) * 5 + i)].Text &&
                    Controls["textBox" + (4 + (Etap - 1) * 5 + i)].Text == bukva[i + 3])
                {
                    minus++;
                }
            }
                              
            
            if (plus > minus)   //  проверка, можно ли подсвечивать желтым (достаточно ли букв в слове).
            {
                Controls["textBox" + (4 + (Etap - 1) * 5)].BackColor = Color.FromArgb(216, 202, 5);

                if (!((Controls["btn" + Controls["textBox" + (4 + (Etap - 1) * 5)].Text] as Button).BackColor == Color.FromArgb(45, 188, 40)))
                {
                    (Controls["btn" + Controls["textBox" + (4 + (Etap - 1) * 5)].Text] as Button).BackColor = Color.FromArgb(216, 202, 5);
                    (Controls["btn" + Controls["textBox" + (4 + (Etap - 1) * 5)].Text] as Button).ForeColor = Color.White;
                }
            }
                    


                // 5-ая буква

            plus = 0;      
            for (int i = 1; i < 6; i++)  //  определяем переменную plus для 5-ой буквы.
            {
                if (Controls["textBox" + (5 + (Etap - 1) * 5)].Text == bukva[i - 1])
                {
                    plus++;
                }
            }
                   
   
            minus = 0;
            for (int i = 1; i < 5; i++)  // определяем переменную minus для 4-ой буквы. 
            {
                if (Controls["textBox" + (5 + (Etap - 1) * 5)].Text == Controls["textBox" + (5 + (Etap - 1) * 5 - i)].Text)
                {
                    minus++;
                }
            }
            
                    
            if (plus > minus)   //  проверка, можно ли подсвечивать желтым (достаточно ли букв в слове).
            {
                Controls["textBox" + (5 + (Etap - 1) * 5)].BackColor = Color.FromArgb(216, 202, 5);

                if (!((Controls["btn" + Controls["textBox" + (5 + (Etap - 1) * 5)].Text] as Button).BackColor == Color.FromArgb(45, 188, 40)))
                {
                    (Controls["btn" + Controls["textBox" + (5 + (Etap - 1) * 5)].Text] as Button).BackColor = Color.FromArgb(216, 202, 5);
                    (Controls["btn" + Controls["textBox" + (5 + (Etap - 1) * 5)].Text] as Button).ForeColor = Color.White;
                }
            }



                    //  ЗЕЛЕНЫЙ ЦВЕТ.

            for (int i = 1; i < 6; i++)
            {
                if (Controls["textBox" + (i + (Etap - 1) * 5)].Text == bukva[i - 1])
                {
                    Controls["textBox" + (i + (Etap - 1) * 5)].BackColor = Color.FromArgb(45, 188, 40);

                    (Controls["btn" + Controls["textBox" + (i + (Etap - 1) * 5)].Text] as Button).BackColor = Color.FromArgb(45, 188, 40);
                    (Controls["btn" + Controls["textBox" + (i + (Etap - 1) * 5)].Text] as Button).ForeColor = Color.White;
                }
            }



                    //  Устанавливаем доступ к строкам.

            for (int i = 1; i < 6; i++)
            {
                Controls["textBox" + (i + (Etap - 1) * 5)].ForeColor = Color.White;  //  делаем буквы белыми.
                (Controls["textBox" + (i + (Etap - 1) * 5)] as TextBox).ReadOnly = true;  //  теперь нельзя редактировать слово.
                Controls["textBox" + (i + (Etap - 1) * 5)].TabStop = false;  //  теперь нельзя фокусироваться на этом слове.

                if (Etap < 6)
                {
                    (Controls["textBox" + (i + Etap * 5)] as TextBox).ReadOnly = false;  //  теперь можно редактировать следующее слово.
                    Controls["textBox" + (i + Etap * 5)].TabStop = true;  //  теперь можно вводить слово.
                    Controls["textBox" + (1 + Etap * 5)].Focus();  //  фокусируемся на новое слово.
                }
            }
                           
            

                    //  Проверка выигрыша.

            int quantityRightLetters = 0;

            for (int i = 1; i < 6; i++)  // высчитываем количество правильных букв в введенном слове.
            {
                if (Controls["textBox" + (i + (Etap - 1) * 5)].Text == bukva[i - 1])
                {
                    quantityRightLetters++;
                }
            }

            if (quantityRightLetters == 5)
            {
                MessageBox.Show("Ты угадал! Это слово - " + RightWord, "Угадал!");
                btnEnter.Enabled = false;  // кнопка проверки слова теперь неактивна.      
                UzheViigral = 1;
            }
                    
            Etap++;
            


                    // Проигрыш - количество попыток исчерпано.

            if (Etap == 7 && UzheViigral == 0)
            {
                MessageBox.Show("Правильное слово - " + RightWord, "Ты не угадал(");
                btnEnter.Enabled = false;  // кнопка проверки слова теперь неактивна.    
            }
        }



        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (btnEnter.Enabled)
            {
                TextBox ctl = (TextBox)sender;

                if ((!(((int)e.KeyCode >= 65 && (int)e.KeyCode <= 90) || ((int)e.KeyCode >= 97 && (int)e.KeyCode <= 122) || 
                    e.KeyCode == Keys.Back)) || (!(InputLanguage.CurrentInputLanguage.Equals(GetLanguage("en")))))  
                {  
                    e.Handled = true;   
                    return;
                }  

                int c = getTextBoxIndex(ctl);

                if (e.KeyCode == Keys.Back)  // назад.
                {
                    if ((c + 1) % 5 != 0)   // на первой букве не идем назад.
                    {
                        b = ctl.Text == "" || ctl.Text == " ";  // повторим (для пустой ячейки).
                        SelectNextControl(ctl, false, true, true, true);
                    }
                }
                else    // вперед.
                {
                    if (c % 5 != 0)   // на последней букве не идем вперед.
                    {
                        SelectNextControl(ctl, true, true, true, true);
                    }
                }
            }
        }



        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (btnEnter.Enabled)
            {
                TextBox ctl = (TextBox)sender;

                if (b)
                {
                    ctl.Text = "";
                    b = false;
                }

                curSender = sender;  // запоминаем sender.
            }
        }



        private int getTextBoxIndex(TextBox ctl)   // поиск индекса текстбокса в массиве текстбоксов.
        {
                int c = 0;   // индекс текстбокса (индексы почему-то в обратном порядке).
                foreach (TextBox tb in this.Controls.OfType<TextBox>())
                {
                    if (ctl == tb)
                    {
                        break;
                    }
                    ++c;
                }

                return c;
        }



        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if (btnEnter.Enabled)
            {
                TextBox ctl = (TextBox)curSender;

                int c = getTextBoxIndex(ctl);

                if (c % 5 == 0)   // на последней букве не идем назад.
                {
                    b = ctl.Text == "" || ctl.Text == " "; // повторим (для пустой ячейки).
                                                          
                    if (b)
                        SelectNextControl(ctl, false, true, true, true);
                    else
                        ctl.Focus();
                }
                else if ((c + 1) % 5 != 0)   // на первой букве не идем назад.
                {
                    b = ctl.Text == "" || ctl.Text == " "; // повторим (для пустой ячейки).
                    SelectNextControl(ctl, false, true, true, true);
                }

                ctl.Text = "";
            }
        }



        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (btnEnter.Enabled)
            {
                if ((e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar >= 'a' && e.KeyChar <= 'z') || ((Keys)e.KeyChar == Keys.Back))
                {

                }
                else
                {
                    e.Handled = true;
                    return;
                }
            }
        }



        private void textBox1_Click(object sender, EventArgs e)
        {
            
        }



        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (ActiveControl.ForeColor == Color.White)
            {
                this.ActiveControl = PreviousTextBox;
            }
        }



        private void textBox1_MouseUp(object sender, MouseEventArgs e)
        {
            
        }



        private void textBox1_Leave(object sender, EventArgs e)  // Запоминаем предыдущий TextBox.
        {
            PreviousTextBox = sender as TextBox;
        }



        private void btn_Click(object sender, EventArgs e)  // Обработчик нажатия букв клавиатуры на форме.
        {
            if (btnEnter.Enabled) 
            {
                TextBox ctl = (TextBox)curSender;

                int c = getTextBoxIndex(ctl);

                if (c % 5 != 0)   // на последней букве не идем вперед.
                {
                    SelectNextControl(ctl, true, true, true, true);
                }
                
                ctl.Text = ((Button)sender).Text;  
            }
        }
    }
}