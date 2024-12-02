using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAME14
{
    public partial class GameWindow : Form
    
    {
        

            
        private bool isClickBlocked = false;//카드들을 터치 막음

        Random Location = new Random();
        //게임에서 무작위 위치를 생성하기 위해 Random 클래스의 인스턴스를 생성합니다. 
        //이를 통해 카드의 위치를 무작위로 섞을 때 사용할 수 있습니다.
        List<Point> points = new List<Point>();
        //points는 좌표(x, y 값)를 저장하는 리스트입니다.
        //게임 시작 시 각 카드의 위치를 기록하거나, 섞인 후 위치를 저장하는 데 사용됩니다.
        bool again = false;
        //이 변수는 다시 클릭 가능 여부를 판단하는 데 사용될 것
        //플레이어가 이미 두 장의 카드를 선택한 경우 클릭을 비활성화하는 데 사용될 수 있습니다.
        PictureBox pendingImage1;
        PictureBox pendingImage2;
        //플레이어가 선택한 두 개의 카드(PictureBox 객체)를 임시로 저장하는 데 사용됩니다.
        //두 카드를 비교해서 같은지 확인하거나, 맞지 않으면 원래 상태로 되돌리기 위해 사용됩니다.
        public GameWindow()
        {
            InitializeComponent();//여러가지 버튼 초기화
        }

        private void GameWindow_Load(object sender, EventArgs e)
        {

            ScoreCounter.Text = "0";//게임시작시  ScoreCounter의 텍스트를 0으로 초기화,게임시작시 점수를 초기화
            label1.Text = "5";
            foreach (PictureBox picture in CardsHolder.Controls)
            {

                picture.Enabled = false;
                points.Add(picture.Location);

            }
            //각 PictureBox의 Enabled 속성을 false로 설정해, 초기 상태에서 비활성화합니다.
            //모든 PictureBox의 위치(Location)를 points 리스트에 추가하여 나중에 섞기 위해 저장합니다.
            foreach (PictureBox picture in CardsHolder.Controls)
            {
                int next = Location.Next(points.Count);
                Point p = points[next];
                picture.Location = p;
                points.Remove(p);
            }
            //저장된 points 리스트를 이용해 각 카드의 위치를 무작위로 섞습니다.
            //Location.Next(points.Count)를 사용해 랜덤한 인덱스를 생성합니다.
            //points[next]에서 해당 위치를 가져와 카드의 위치(Location)를 변경합니다.
            //가져온 위치는 points 리스트에서 제거해 중복 사용을 방지합니다.
            timer2.Start();
            timer1.Start();
            //두 개의 타이머(timer1과 timer2)를 시작합니다.
            Card1.Image = Properties.Resources.Card1;
            DupCard1.Image = Properties.Resources.Card1;
            Card2.Image = Properties.Resources.Card2;
            DupCard2.Image = Properties.Resources.Card2;
            Card3.Image = Properties.Resources.Card3;
            DupCard3.Image = Properties.Resources.Card3;
            Card4.Image = Properties.Resources.Card4;
            DupCard4.Image = Properties.Resources.Card4;
            Card5.Image = Properties.Resources.Card5;
            DupCard5.Image = Properties.Resources.Card5;
            Card6.Image = Properties.Resources.Card6;
            DupCard6.Image = Properties.Resources.Card6;
            Card7.Image = Properties.Resources.Card7;
            DupCard7.Image = Properties.Resources.Card7;
            Card8.Image = Properties.Resources.Card8;
            DupCard8.Image = Properties.Resources.Card8;
            Card9.Image = Properties.Resources.Card9;
            DupCard9.Image = Properties.Resources.Card9;
            Card10.Image = Properties.Resources.Card10;
            DupCard10.Image = Properties.Resources.Card10;
            Card11.Image = Properties.Resources.Card11;
            DupCard11.Image = Properties.Resources.Card11;
            Card12.Image = Properties.Resources.Card12;
            DupCard12.Image = Properties.Resources.Card12;

            //Properties.Resources를 통해 프로젝트 리소스에 저장된 이미지 파일을 참조합니다.

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();//timer1은 한 번만 실행되는 초기화 타이머로 보이며, 더 이상 실행되지 않도록 중지합니다.
            foreach (PictureBox picture in CardsHolder.Controls)//CardsHolder에 있는 모든 PictureBox(카드 컨트롤)를 순회하며 각 카드에 대해 아래 작업을 수행합니다
            {
                picture.Enabled = true;//모든 카드를 활성화하여 클릭 가능하게 만듭니다.
                picture.Cursor = Cursors.Hand;//마우스를 카드 위에 올렸을 때 커서가 손 모양으로 표시되도록 설정합니다.
                picture.Image = Properties.Resources.Cover2;//각 카드의 이미지를 "뒷면"으로 설정하여 숨깁니다.

            }
        }

        private void timer2_Tick(object sender, EventArgs e)//제한 시간을 관리합니다. 시간이 다 되면 타이머를 멈춥니다.
                                                            //label1에 남은 시간을 실시간으로 업데이트하여 화면에 표시합니다.

        {
            int timer = Convert.ToInt32(label1.Text);//label1에 표시된 텍스트 값을 정수로 변환하여 timer 변수에 저장합니다.
            //이 변수는 남은 시간을 나타냅니다.
            timer = timer - 1;//timer 값을 1초 감소시킵니다.
            label1.Text = Convert.ToString(timer);//감소된 시간을 다시 label1에 업데이트하여 화면에 표시합니다.
            if (timer == 0)
            {
                timer2.Stop();//타이머를 멈춥니다.
                //더 이상 시간이 감소하지 않도록 설정합니다.
            }
        }
        //chnage
        #region Cards
        private void Card1_Click(object sender, EventArgs e)//카드 Card1 클릭 시 동작을 정의합니다. 카드의 이미지를 보여주고, 선택한 카드의 정보를 관리합니다.
        {
            PictureBox clickedCard = sender as PictureBox;// 클릭된 PictureBox를 가져옵니다.
            if (isClickBlocked)// 클릭이 일시적으로 차단된 경우(두 카드 비교 중) 아무 작업도 하지 않음
                return;
            // 이미 Card1이 선택된 경우 중복 선택을 방지합니다.
            if (pendingImage1 == Card1 || pendingImage2 == Card1)
                return;

            Card1.Image = Properties.Resources.Card1; // Card1의 이미지를 표시

            if (pendingImage1 == null) // 첫 번째 카드가 선택되지 않은 경우
            {
                pendingImage1 = Card1; // 첫 번째 카드로 Card1을 선택합니다.
            }
            else if (pendingImage1 != null && pendingImage2 == null) // 첫 번째 카드는 선택되었고, 두 번째 카드가 선택되지 않은 경우
            {
                pendingImage2 = Card1; // 두 번째 카드로 Card1을 선택합니다.
            }

            if (pendingImage1 != null && pendingImage2 != null)// 두 개의 카드가 모두 선택되었을 때
            {
                isClickBlocked = true;// 두 카드가 비교되는 동안 추가 클릭을 차단합니다.
                if (pendingImage1.Tag == pendingImage2.Tag)// 두 카드의 태그가 일치하는지 확인합니다. (짝이 맞는 경우)
                {
                    pendingImage1.Enabled = false;// 첫 번째 카드 클릭 비활성화(짝 맞춘 카드)
                    pendingImage2.Enabled = false;// 두 번째 카드 클릭 비활성화(짝 맞춘 카드)


                    pendingImage1 = null;// 선택된 카드 정보 초기화
                    pendingImage2 = null;
                    // 점수 증가: 짝을 맞췄을 때 10점 추가
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                    isClickBlocked = false; // 클릭 차단 해제 
                }
                else// 두 카드의 태그가 일치하지 않는 경우
                {
                    // 점수 감소: 짝을 맞추지 못했을 때 10점 감점
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);

                    timer3.Start();// 일정 시간 후에 두 카드를 다시 뒤집기 위해 타이머 시작
                }
            }
        }

        private void DupCard1_Click(object sender, EventArgs e)
        {
            PictureBox clickedCard = sender as PictureBox;
            // 이미 DupCard1이 선택된 경우 아무 작업도 하지 않음
            if (isClickBlocked)
                return;
            if (pendingImage1 == DupCard1 || pendingImage2 == DupCard1)
                return;

            DupCard1.Image = Properties.Resources.Card1; // DupCard1의 이미지를 표시

            if (pendingImage1 == null)
            {
                pendingImage1 = DupCard1; // 첫 번째 카드 선택
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = DupCard1; // 두 번째 카드 선택
            }

            if (pendingImage1 != null && pendingImage2 != null)
            {
                isClickBlocked = true;
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1.Enabled = false;
                    pendingImage2.Enabled = false;

                    pendingImage1 = null;
                    pendingImage2 = null;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                    isClickBlocked = false;
                }
                else
                {
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    timer3.Start();
                }
            }
        }

        private void Card2_Click(object sender, EventArgs e)
        {
            PictureBox clickedCard = sender as PictureBox;
            // 이미 Card2가 선택된 경우 아무 작업도 하지 않음
            if (isClickBlocked)
                return;
            if (pendingImage1 == Card2 || pendingImage2 == Card2)
                return;

            Card2.Image = Properties.Resources.Card2; // Card2의 이미지를 표시

            if (pendingImage1 == null)
            {
                pendingImage1 = Card2; // 첫 번째 카드 선택
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = Card2; // 두 번째 카드 선택
            }

            if (pendingImage1 != null && pendingImage2 != null)
            {
                isClickBlocked = true;
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1.Enabled = false;
                    pendingImage2.Enabled = false;

                    pendingImage1 = null;
                    pendingImage2 = null;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                    isClickBlocked = false;
                }
                else
                {
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    timer3.Start();
                }
            }
        }

        private void DupCard2_Click(object sender, EventArgs e)
        {
            PictureBox clickedCard = sender as PictureBox;
            // 이미 DupCard2가 선택된 경우 아무 작업도 하지 않음
            if (isClickBlocked)
                return;
            if (pendingImage1 == DupCard2 || pendingImage2 == DupCard2)
                return;

            DupCard2.Image = Properties.Resources.Card2; // DupCard2의 이미지를 표시

            if (pendingImage1 == null)
            {
                pendingImage1 = DupCard2; // 첫 번째 카드 선택
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = DupCard2; // 두 번째 카드 선택
            }

            if (pendingImage1 != null && pendingImage2 != null)
            {
                isClickBlocked = true;
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1.Enabled = false;
                    pendingImage2.Enabled = false;

                    pendingImage1 = null;
                    pendingImage2 = null;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                    isClickBlocked = false;
                }
                else
                {
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    timer3.Start();
                }
            }
        }

        private void Card3_Click(object sender, EventArgs e)
        {
            PictureBox clickedCard = sender as PictureBox;
            if (isClickBlocked)
                return;
            // 이미 Card1이 선택된 경우 아무 작업도 하지 않음
            if (pendingImage1 == Card3 || pendingImage2 == Card3)
                return;

            Card3.Image = Properties.Resources.Card3; // Card1의 이미지를 표시

            if (pendingImage1 == null)
            {
                pendingImage1 = Card3; // 첫 번째 카드 선택
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = Card3; // 두 번째 카드 선택
            }

            if (pendingImage1 != null && pendingImage2 != null)
            {
                isClickBlocked = true;
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1.Enabled = false;
                    pendingImage2.Enabled = false;

                    pendingImage1 = null;
                    pendingImage2 = null;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                    isClickBlocked = false;
                }
                else
                {
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10); // 점수 감소
                    timer3.Start(); // 일정 시간 뒤 카드 뒤집기
                }
            }
        }

        private void DupCard3_Click(object sender, EventArgs e)
        {
            PictureBox clickedCard = sender as PictureBox;
            // 이미 DupCard1이 선택된 경우 아무 작업도 하지 않음
            if (isClickBlocked)
                return;
            if (pendingImage1 == DupCard3 || pendingImage2 == DupCard3)
                return;

            DupCard3.Image = Properties.Resources.Card3; // DupCard1의 이미지를 표시

            if (pendingImage1 == null)
            {
                pendingImage1 = DupCard3; // 첫 번째 카드 선택
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = DupCard3; // 두 번째 카드 선택
            }

            if (pendingImage1 != null && pendingImage2 != null)
            {
                isClickBlocked = true;
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1.Enabled = false;
                    pendingImage2.Enabled = false;

                    pendingImage1 = null;
                    pendingImage2 = null;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                    isClickBlocked = false;
                }
                else
                {
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    timer3.Start();
                }
            }
        }

        private void Card4_Click(object sender, EventArgs e)
        {
            PictureBox clickedCard = sender as PictureBox;
            if (isClickBlocked)
                return;

            // 이미 Card1이 선택된 경우 아무 작업도 하지 않음
            if (pendingImage1 == Card4 || pendingImage2 == Card4)
                return;

            Card4.Image = Properties.Resources.Card4; // Card1의 이미지를 표시

            if (pendingImage1 == null)
            {
                pendingImage1 = Card4; // 첫 번째 카드 선택
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = Card4; // 두 번째 카드 선택
            }

            if (pendingImage1 != null && pendingImage2 != null)
            {
                isClickBlocked = true;
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1.Enabled = false;
                    pendingImage2.Enabled = false;

                    pendingImage1 = null;
                    pendingImage2 = null;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                    isClickBlocked = false;
                }
                else
                {
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10); // 점수 감소
                    timer3.Start(); // 일정 시간 뒤 카드 뒤집기
                }
            }

        }

        private void DupCard4_Click(object sender, EventArgs e)
        {
            PictureBox clickedCard = sender as PictureBox;
            // 이미 DupCard1이 선택된 경우 아무 작업도 하지 않음
            if (isClickBlocked)
                return;
            if (pendingImage1 == DupCard4 || pendingImage2 == DupCard4)
                return;

            DupCard4.Image = Properties.Resources.Card4; // DupCard1의 이미지를 표시

            if (pendingImage1 == null)
            {
                pendingImage1 = DupCard4; // 첫 번째 카드 선택
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = DupCard4; // 두 번째 카드 선택
            }

            if (pendingImage1 != null && pendingImage2 != null)
            {
                isClickBlocked = true;
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1.Enabled = false;
                    pendingImage2.Enabled = false;

                    pendingImage1 = null;
                    pendingImage2 = null;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                    isClickBlocked = false;
                }
                else
                {
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    timer3.Start();
                }
            }
        }

        private void Card5_Click(object sender, EventArgs e)
        {
            PictureBox clickedCard = sender as PictureBox;

            // 이미 Card1이 선택된 경우 아무 작업도 하지 않음
            if (isClickBlocked)
                return;
            if (pendingImage1 == Card5 || pendingImage2 == Card5)
                return;

            Card5.Image = Properties.Resources.Card5; // Card1의 이미지를 표시

            if (pendingImage1 == null)
            {
                pendingImage1 = Card5; // 첫 번째 카드 선택
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = Card5; // 두 번째 카드 선택
            }

            if (pendingImage1 != null && pendingImage2 != null)
            {
                isClickBlocked = true;
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1.Enabled = false;
                    pendingImage2.Enabled = false;

                    pendingImage1 = null;
                    pendingImage2 = null;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                    isClickBlocked = false;
                }
                else
                {
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10); // 점수 감소
                    timer3.Start(); // 일정 시간 뒤 카드 뒤집기
                }
            }
        }

        private void DupCard5_Click(object sender, EventArgs e)
        {
            PictureBox clickedCard = sender as PictureBox;
            // 이미 DupCard1이 선택된 경우 아무 작업도 하지 않음
            if (isClickBlocked)
                return;
            if (pendingImage1 == DupCard5 || pendingImage2 == DupCard5)
                return;

            DupCard5.Image = Properties.Resources.Card5; // DupCard1의 이미지를 표시

            if (pendingImage1 == null)
            {
                pendingImage1 = DupCard5; // 첫 번째 카드 선택
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = DupCard5; // 두 번째 카드 선택
            }

            if (pendingImage1 != null && pendingImage2 != null)
            {
                isClickBlocked = true;
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1.Enabled = false;
                    pendingImage2.Enabled = false;

                    pendingImage1 = null;
                    pendingImage2 = null;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                    isClickBlocked = false;
                }
                else
                {
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    timer3.Start();
                }
            }
        }

        private void Card6_Click(object sender, EventArgs e)
        {
            PictureBox clickedCard = sender as PictureBox;

            // 이미 Card1이 선택된 경우 아무 작업도 하지 않음
            if (isClickBlocked)
                return;
            if (pendingImage1 == Card6 || pendingImage2 == Card6)
                return;

            Card6.Image = Properties.Resources.Card6; // Card1의 이미지를 표시

            if (pendingImage1 == null)
            {
                pendingImage1 = Card6; // 첫 번째 카드 선택
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = Card6; // 두 번째 카드 선택
            }

            if (pendingImage1 != null && pendingImage2 != null)
            {
                isClickBlocked = true;
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1.Enabled = false;
                    pendingImage2.Enabled = false;

                    pendingImage1 = null;
                    pendingImage2 = null;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                    isClickBlocked = false;
                }
                else
                {
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10); // 점수 감소
                    timer3.Start(); // 일정 시간 뒤 카드 뒤집기
                }
            }
        }

        private void DupCard6_Click(object sender, EventArgs e)
        {
            PictureBox clickedCard = sender as PictureBox;
            // 이미 DupCard1이 선택된 경우 아무 작업도 하지 않음
            if (isClickBlocked)
                return;
            if (pendingImage1 == DupCard6 || pendingImage2 == DupCard6)
                return;

            DupCard6.Image = Properties.Resources.Card6; // DupCard1의 이미지를 표시

            if (pendingImage1 == null)
            {
                pendingImage1 = DupCard6; // 첫 번째 카드 선택
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = DupCard6; // 두 번째 카드 선택
            }

            if (pendingImage1 != null && pendingImage2 != null)
            {
                isClickBlocked = true;
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1.Enabled = false;
                    pendingImage2.Enabled = false;

                    pendingImage1 = null;
                    pendingImage2 = null;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                    isClickBlocked = false;
                }
                else
                {
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    timer3.Start();
                }
            }
        }

        private void Card7_Click(object sender, EventArgs e)
        {
            PictureBox clickedCard = sender as PictureBox;

            // 이미 Card1이 선택된 경우 아무 작업도 하지 않음
            if (isClickBlocked)
                return;
            if (pendingImage1 == Card7 || pendingImage2 == Card7)
                return;

            Card7.Image = Properties.Resources.Card7; // Card1의 이미지를 표시

            if (pendingImage1 == null)
            {
                pendingImage1 = Card7; // 첫 번째 카드 선택
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = Card7; // 두 번째 카드 선택
            }

            if (pendingImage1 != null && pendingImage2 != null)
            {
                isClickBlocked = true;
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1.Enabled = false;
                    pendingImage2.Enabled = false;

                    pendingImage1 = null;
                    pendingImage2 = null;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                    isClickBlocked = false;
                }
                else
                {
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10); // 점수 감소
                    timer3.Start(); // 일정 시간 뒤 카드 뒤집기
                }
            }
        }

        private void DupCard7_Click(object sender, EventArgs e)
        {
            PictureBox clickedCard = sender as PictureBox;
            // 이미 DupCard1이 선택된 경우 아무 작업도 하지 않음
            if (isClickBlocked)
                return;
            if (pendingImage1 == DupCard7 || pendingImage2 == DupCard7)
                return;

            DupCard7.Image = Properties.Resources.Card7; // DupCard1의 이미지를 표시

            if (pendingImage1 == null)
            {
                pendingImage1 = DupCard7; // 첫 번째 카드 선택
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = DupCard7; // 두 번째 카드 선택
            }

            if (pendingImage1 != null && pendingImage2 != null)
            {
                isClickBlocked = true;
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1.Enabled = false;
                    pendingImage2.Enabled = false;

                    pendingImage1 = null;
                    pendingImage2 = null;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                    isClickBlocked = false;
                }
                else
                {
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    timer3.Start();
                }
            }
        }

        private void Card8_Click(object sender, EventArgs e)
        {
            PictureBox clickedCard = sender as PictureBox;

            // 이미 Card1이 선택된 경우 아무 작업도 하지 않음
            if (isClickBlocked)
                return;
            if (pendingImage1 == Card8 || pendingImage2 == Card8)
                return;

            Card8.Image = Properties.Resources.Card8; // Card1의 이미지를 표시

            if (pendingImage1 == null)
            {
                pendingImage1 = Card8; // 첫 번째 카드 선택
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = Card8; // 두 번째 카드 선택
            }

            if (pendingImage1 != null && pendingImage2 != null)
            {
                isClickBlocked = true;
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1.Enabled = false;
                    pendingImage2.Enabled = false;

                    pendingImage1 = null;
                    pendingImage2 = null;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                    isClickBlocked = false;
                }
                else
                {
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10); // 점수 감소
                    timer3.Start(); // 일정 시간 뒤 카드 뒤집기
                }
            }
        }

        private void DupCard8_Click(object sender, EventArgs e)
        {
            PictureBox clickedCard = sender as PictureBox;
            // 이미 DupCard1이 선택된 경우 아무 작업도 하지 않음
            if (isClickBlocked)
                return;
            if (pendingImage1 == DupCard8 || pendingImage2 == DupCard8)
                return;

            DupCard8.Image = Properties.Resources.Card8; // DupCard1의 이미지를 표시

            if (pendingImage1 == null)
            {
                pendingImage1 = DupCard8; // 첫 번째 카드 선택
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = DupCard8; // 두 번째 카드 선택
            }

            if (pendingImage1 != null && pendingImage2 != null)
            {
                isClickBlocked = true;
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1.Enabled = false;
                    pendingImage2.Enabled = false;

                    pendingImage1 = null;
                    pendingImage2 = null;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                    isClickBlocked = false;
                }
                else
                {
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    timer3.Start();
                }
            }
        }

        private void Card9_Click(object sender, EventArgs e)
        {
            PictureBox clickedCard = sender as PictureBox;

            // 이미 Card1이 선택된 경우 아무 작업도 하지 않음
            if (isClickBlocked)
                return;
            if (pendingImage1 == Card9 || pendingImage2 == Card9)
                return;

            Card9.Image = Properties.Resources.Card9; // Card1의 이미지를 표시

            if (pendingImage1 == null)
            {
                pendingImage1 = Card9; // 첫 번째 카드 선택
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = Card9; // 두 번째 카드 선택
            }

            if (pendingImage1 != null && pendingImage2 != null)
            {
                isClickBlocked = true;
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1.Enabled = false;
                    pendingImage2.Enabled = false;

                    pendingImage1 = null;
                    pendingImage2 = null;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                    isClickBlocked = false;
                }
                else
                {
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10); // 점수 감소
                    timer3.Start(); // 일정 시간 뒤 카드 뒤집기
                }
            }
        }

        private void DupCard9_Click(object sender, EventArgs e)
        {
            PictureBox clickedCard = sender as PictureBox;
            // 이미 DupCard1이 선택된 경우 아무 작업도 하지 않음
            if (isClickBlocked)
                return;
            if (pendingImage1 == DupCard9 || pendingImage2 == DupCard9)
                return;

            DupCard9.Image = Properties.Resources.Card9; // DupCard1의 이미지를 표시

            if (pendingImage1 == null)
            {
                pendingImage1 = DupCard9; // 첫 번째 카드 선택
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = DupCard9; // 두 번째 카드 선택
            }

            if (pendingImage1 != null && pendingImage2 != null)
            {
                isClickBlocked = true;
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1.Enabled = false;
                    pendingImage2.Enabled = false;

                    pendingImage1 = null;
                    pendingImage2 = null;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                    isClickBlocked = false;
                }
                else
                {
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    timer3.Start();
                }
            }
        }

        private void Card10_Click(object sender, EventArgs e)
        {
            PictureBox clickedCard = sender as PictureBox;

            // 이미 Card1이 선택된 경우 아무 작업도 하지 않음
            if (isClickBlocked)
                return;
            if (pendingImage1 == Card10 || pendingImage2 == Card10)
                return;

            Card10.Image = Properties.Resources.Card10; // Card1의 이미지를 표시

            if (pendingImage1 == null)
            {
                pendingImage1 = Card10; // 첫 번째 카드 선택
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = Card10; // 두 번째 카드 선택
            }

            if (pendingImage1 != null && pendingImage2 != null)
            {
                isClickBlocked = true;
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1.Enabled = false;
                    pendingImage2.Enabled = false;

                    pendingImage1 = null;
                    pendingImage2 = null;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                    isClickBlocked = false;
                }
                else
                {
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10); // 점수 감소
                    timer3.Start(); // 일정 시간 뒤 카드 뒤집기
                }
            }
        }

        private void DupCard10_Click(object sender, EventArgs e)
        {
            PictureBox clickedCard = sender as PictureBox;
            // 이미 DupCard1이 선택된 경우 아무 작업도 하지 않음
            if (isClickBlocked)
                return;
            if (pendingImage1 == DupCard10 || pendingImage2 == DupCard10)
                return;

            DupCard10.Image = Properties.Resources.Card10; // DupCard1의 이미지를 표시

            if (pendingImage1 == null)
            {
                pendingImage1 = DupCard10; // 첫 번째 카드 선택
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = DupCard10; // 두 번째 카드 선택
            }

            if (pendingImage1 != null && pendingImage2 != null)
            {
                isClickBlocked = true;
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1.Enabled = false;
                    pendingImage2.Enabled = false;

                    pendingImage1 = null;
                    pendingImage2 = null;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                    isClickBlocked = false;
                }
                else
                {
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    timer3.Start();
                }
            }
        }

        private void Card11_Click(object sender, EventArgs e)
        {
            PictureBox clickedCard = sender as PictureBox;

            // 이미 Card1이 선택된 경우 아무 작업도 하지 않음
            if (isClickBlocked)
                return;
            if (pendingImage1 == Card11 || pendingImage2 == Card11)
                return;

            Card11.Image = Properties.Resources.Card11; // Card1의 이미지를 표시

            if (pendingImage1 == null)
            {
                pendingImage1 = Card11; // 첫 번째 카드 선택
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = Card11; // 두 번째 카드 선택
            }

            if (pendingImage1 != null && pendingImage2 != null)
            {
                isClickBlocked = true;
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1.Enabled = false;
                    pendingImage2.Enabled = false;

                    pendingImage1 = null;
                    pendingImage2 = null;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                    isClickBlocked = false;
                }
                else
                {
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10); // 점수 감소
                    timer3.Start(); // 일정 시간 뒤 카드 뒤집기
                }
            }
        }

        private void DupCard11_Click(object sender, EventArgs e)
        {
            PictureBox clickedCard = sender as PictureBox;
            // 이미 DupCard1이 선택된 경우 아무 작업도 하지 않음
            if (isClickBlocked)
                return;
            if (pendingImage1 == DupCard11 || pendingImage2 == DupCard11)
                return;

            DupCard11.Image = Properties.Resources.Card11; // DupCard1의 이미지를 표시

            if (pendingImage1 == null)
            {
                pendingImage1 = DupCard11; // 첫 번째 카드 선택
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = DupCard11; // 두 번째 카드 선택
            }

            if (pendingImage1 != null && pendingImage2 != null)
            {
                isClickBlocked = true;
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1.Enabled = false;
                    pendingImage2.Enabled = false;

                    pendingImage1 = null;
                    pendingImage2 = null;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                    isClickBlocked = false;
                }
                else
                {
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    timer3.Start();
                }
            }
        }

        private void Card12_Click(object sender, EventArgs e)
        {
            PictureBox clickedCard = sender as PictureBox;

            // 이미 Card1이 선택된 경우 아무 작업도 하지 않음
            if (isClickBlocked)
                return;
            if (pendingImage1 == Card12 || pendingImage2 == Card12)
                return;

            Card12.Image = Properties.Resources.Card12; // Card1의 이미지를 표시

            if (pendingImage1 == null)
            {
                pendingImage1 = Card12; // 첫 번째 카드 선택
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = Card12; // 두 번째 카드 선택
            }

            if (pendingImage1 != null && pendingImage2 != null)
            {
                isClickBlocked = true;
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1.Enabled = false;
                    pendingImage2.Enabled = false;

                    pendingImage1 = null;
                    pendingImage2 = null;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                    isClickBlocked = false;
                }
                else
                {
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10); // 점수 감소
                    timer3.Start(); // 일정 시간 뒤 카드 뒤집기
                }
            }
        }

        private void DupCard12_Click(object sender, EventArgs e)
        {
            PictureBox clickedCard = sender as PictureBox;
            // 이미 DupCard1이 선택된 경우 아무 작업도 하지 않음
            if (isClickBlocked)
                return;
            if (pendingImage1 == DupCard12 || pendingImage2 == DupCard12)
                return;

            DupCard12.Image = Properties.Resources.Card12; // DupCard1의 이미지를 표시

            if (pendingImage1 == null)
            {
                pendingImage1 = DupCard12; // 첫 번째 카드 선택
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = DupCard12; // 두 번째 카드 선택
            }

            if (pendingImage1 != null && pendingImage2 != null)
            {
                isClickBlocked = true;
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1.Enabled = false;
                    pendingImage2.Enabled = false;

                    pendingImage1 = null;
                    pendingImage2 = null;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                    isClickBlocked = false;
                }
                else
                {
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    timer3.Start();
                }
            }
        }
        #endregion

        private void timer3_Tick(object sender, EventArgs e)// 목적 잘못된 카드 선택 시, 선택된 두 장의 카드를 다시 뒤집어 원래 상태로 되돌립니다.
                                                            //선택된 두 카드를 초기화하여 다음 비교가 가능하도록 준비합니다.
        {

            // timer3이 작동할 때 카드 뒤집기
            pendingImage1.Image = Properties.Resources.Cover2;
            pendingImage2.Image = Properties.Resources.Cover2;

            // 상태 초기화
            pendingImage1 = null;
            pendingImage2 = null;

            // 카드 클릭 차단 해제
            isClickBlocked = false;

            // timer3을 중지하여 반복되지 않게 설정
            timer3.Stop();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop(); // 기존 타이머 정지
            timer1.Interval = 5000; // 타이머 간격을 5초로 재설정 (이미 설정되어 있다면 생략 가능)
            GameWindow_Load(sender, e); // 게임 초기화
            timer1.Start(); // 타이머 시작
        }
    }
}
