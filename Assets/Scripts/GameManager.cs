using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TileBoard board; // 游戏的核心玩法面板
    public CanvasGroup gameOver; // 游戏结束的界面
    public TextMeshProUGUI scoreText; // 分数
    public TextMeshProUGUI hiscoreText;// 最高分数

    private int score;

    private void Start()
    {
        NewGame();
    }
    
    /// <summary>
    /// 开始新游戏
    /// </summary>
    public void NewGame()
    {
        // 还原分数
        SetScore(0);
        
        // 加载最高分数
        hiscoreText.text = LoadHiscore().ToString();

        // 隐藏游戏结束面板
        gameOver.alpha = 0f;
        gameOver.interactable = false;

        // 初始化核心逻辑
        board.ClearBoard();
        board.CreateTile();
        board.CreateTile();
        board.enabled = true;
    }
    
    /// <summary>
    /// 游戏结束，显示面板
    /// </summary>
    public void GameOver()
    {
        board.enabled = false;
        gameOver.interactable = true;
        PlayerPrefs.Save();
        
        StartCoroutine(FadeAnimate(gameOver, 1f, 1f));
    }
    
    /// <summary>
    /// 用于将某个窗口，在指定时间内，完成透明的变化
    /// </summary>
    /// <param name="canvasGroup">哪个面板</param>
    /// <param name="to">透明度变化的值</param>
    /// <param name="delay">使用多长时间</param>
    /// <returns></returns>
    private IEnumerator FadeAnimate(CanvasGroup canvasGroup, float to, float delay = 0f)
    {
        yield return new WaitForSeconds(delay);

        float elapsed = 0f;
        float duration = 0.5f;
        float from = canvasGroup.alpha;

        while (elapsed < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = to;
    }
    
    /// <summary>
    /// 增加分数
    /// </summary>
    /// <param name="points"></param>
    public void IncreaseScore(int points)
    {
        SetScore(score + points);
    }
    
      /// <summary>
     /// 设置分数
     /// </summary>
     /// <param name="score"></param>
    private void SetScore(int score)
    {
        this.score = score;
        scoreText.text = score.ToString();

        // 保存分数
        SaveHiscore();
    }

    /// <summary>
    /// 如果已经超过历史分数，那么就将当前分数设置为最高分数
    /// </summary>
    private void SaveHiscore()
    {
        int hiscore = LoadHiscore();

        if (score > hiscore) {
            PlayerPrefs.SetInt("hiscore", score);
        }
    }
    
    /// <summary>
    /// 加载最高分数
    /// </summary>
    /// <returns></returns>
    private int LoadHiscore()
    {
        return PlayerPrefs.GetInt("hiscore", 0);
    }

}
