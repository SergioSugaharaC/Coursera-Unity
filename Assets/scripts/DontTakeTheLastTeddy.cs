using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Game manager
/// </summary>
public class DontTakeTheLastTeddy : MonoBehaviour{
    [SerializeField] private PlayerName startingPlayer = PlayerName.Player1;
    [SerializeField] private Difficulty player1Difficulty = Difficulty.Hard;
    [SerializeField] private Difficulty player2Difficulty = Difficulty.Hard;

    [SerializeField] private int gamesPerDifficulty = 10;
    int currentTimePerDifficulty;
    Difficulty[][] difficultyMatches;
    Difficulty[] currentDifficulties;
    int currentMatch;

    int nTime;
    Timer timer;

    Board board;
    Player player1;
    Player player2;

    // events invoked by class
    TakeTurn takeTurnEvent = new TakeTurn();
    GameOver gameOverEvent = new GameOver();
    StartGame startGameEvent = new StartGame();
    TestOver testOverEvent = new TestOver();

    /// <summary>
    /// Awake is called before Start
    /// </summary>
    void Awake(){
        // retrieve board and player references
        board = GameObject.FindGameObjectWithTag("Board").GetComponent<Board>();
        player1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<Player>();
        player2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<Player>();

        timer = GetComponent<Timer>();

        difficultyMatches = new Difficulty[][]{
            new Difficulty[] { Difficulty.Easy, Difficulty.Easy},
            new Difficulty[] { Difficulty.Medium, Difficulty.Medium},
            new Difficulty[] { Difficulty.Hard, Difficulty.Hard},
            new Difficulty[] { Difficulty.Easy, Difficulty.Medium},
            new Difficulty[] { Difficulty.Easy, Difficulty.Hard},
            new Difficulty[] { Difficulty.Medium, Difficulty.Hard}
        };

        // register as invoker and listener
        EventManager.AddTakeTurnInvoker(this);
        EventManager.AddGameOverInvoker(this);
        EventManager.AddStartGameInvoker(this);
        EventManager.AddTestOverInvoker(this);
        EventManager.AddTurnOverListener(HandleTurnOverEvent);
    }

	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start(){
        nTime = 0;
        currentTimePerDifficulty = 0;
        currentMatch = 0;

        timer.Duration = 0.01f;
        timer.AddTimerFinishedListener(StartNewGameConfiguration);

        StartNewGameConfiguration();
    }

    /// <summary>
    /// Adds the given listener for the TakeTurn event
    /// </summary>
    /// <param name="listener">listener</param>
    public void AddTakeTurnListener(UnityAction<PlayerName, Configuration> listener){
        takeTurnEvent.AddListener(listener);
    }

    /// <summary>
    /// Adds the given listener for the GameOver event
    /// </summary>
    /// <param name="listener">listener</param>
    public void AddGameOverListener(UnityAction<PlayerName, int> listener){
        gameOverEvent.AddListener(listener);
    }

    public void AddStartGameListener(UnityAction listener){
        startGameEvent.AddListener(listener);
    }

    public void AddTestOverListener(UnityAction listener){
        testOverEvent.AddListener(listener);
    }

    void StartNewGameConfiguration(){
        startingPlayer = nTime % 2 == 0 ? PlayerName.Player1 : PlayerName.Player2;

        currentDifficulties = difficultyMatches[currentMatch];
        player1Difficulty = currentDifficulties[0];
        player2Difficulty = currentDifficulties[1];

        nTime++;
        if (currentTimePerDifficulty >= gamesPerDifficulty){
            currentTimePerDifficulty = 0;
            currentMatch++;
            if (currentMatch >= difficultyMatches.Length){
                testOverEvent.Invoke();
                return;
            }
        }
        currentTimePerDifficulty++;
        startGameEvent.Invoke();
        StartGame(startingPlayer, player1Difficulty, player2Difficulty);
    }

    /// <summary>
    /// Starts a game with the given player taking the
    /// first turn
    /// </summary>
    /// <param name="firstPlayer">player taking first turn</param>
    /// <param name="player1Difficulty">difficulty for player 1</param>
    /// <param name="player2Difficulty">difficulty for player 2</param>
    void StartGame(PlayerName firstPlayer, Difficulty player1Difficulty,
        Difficulty player2Difficulty){
        // set player difficulties
        player1.Difficulty = player1Difficulty;
        player2.Difficulty = player2Difficulty;

        // create new board
        board.CreateNewBoard();
        takeTurnEvent.Invoke(firstPlayer, board.Configuration);
    }

    /// <summary>
    /// Handles the TurnOver event by having the 
    /// other player take their turn
    /// </summary>
    /// <param name="player">who finished their turn</param>
    /// <param name="newConfiguration">the new board configuration</param>
    void HandleTurnOverEvent(PlayerName player, Configuration newConfiguration){
        board.Configuration = newConfiguration;

        // check for game over
        if (newConfiguration.Empty){
            // fire event with winner
            if (player == PlayerName.Player1)
                gameOverEvent.Invoke(PlayerName.Player2, currentMatch);
            else
                gameOverEvent.Invoke(PlayerName.Player1, currentMatch);
            timer.Run();
        } else
            // game not over, so give other player a turn
            if (player == PlayerName.Player1)
                takeTurnEvent.Invoke(PlayerName.Player2, newConfiguration);
            else
                takeTurnEvent.Invoke(PlayerName.Player1, newConfiguration);
    }
}
