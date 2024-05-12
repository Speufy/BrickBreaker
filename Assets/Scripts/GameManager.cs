
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

   public Ball ball;
   public Paddle paddle;

   public int score = 0;
   public int lives = 3;
   public int level = 1;

   public Brick[] bricks;

   public void Awake()
   {
      DontDestroyOnLoad(this.gameObject);
      SceneManager.sceneLoaded += OnLevelLoaded;

   }

   public void Start()
   {
      NewGame();
   }

   private void NewGame()
   {
      this.score = 0;
      this.lives = 3;
      LoadLevel(1);

   }

   public void OnLevelLoaded(Scene scene, LoadSceneMode mode){
      this.ball = FindObjectOfType<Ball>() ;
      this.paddle = FindObjectOfType<Paddle>();
      this.bricks = FindObjectsOfType<Brick>();
   }

   private void LoadLevel(int level)
   {
      this.level = level;
      SceneManager.LoadScene("Level_" + level);

   }

   private void ResetLevel()
   {
      this.ball.ResetBall();
      this.paddle.ResetPaddle();
   }

   private void GameOver()
   {
      NewGame();
   }

   public void Hit(Brick brick)
   {
      this.score += brick.points;
      if(Cleared()){
         LoadLevel(this.level + 1);

      }
   }

   public void Miss()
   {

      this.lives--;
      if (this.lives > 0)
      {
         ResetLevel();
      }
      else
      {
         GameOver();
      }
   }
   private bool Cleared(){
      for (int i = 0 ; i < this.bricks.Length; i++)
      {
         if(this.bricks[i].gameObject.activeInHierarchy && !this.bricks[i].unbreakable) {
            return false;
         }
      }
      return true;
      }
      
}
