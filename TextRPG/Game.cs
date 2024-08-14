﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.GameObjects.Monsters;
using TextRPG.Players;
using TextRPG.Scenes;

namespace TextRPG
{
    public class Game
    {
        private bool isRuning;

        private Scene[] scenes = new Scene[(int)SceneType.SIZE];
        private Scene curScene;
        private Scene prevScene;

        public Scene CurScene { get { return curScene; } }

        private Player player;
        public Player Player { get { return player; } set { player = value; } }

        Stack<Scene> aaa = new Stack<Scene>();

        public void Run()
        {
            Start();

            while (isRuning)
            {
                Render();
                Input();
                Update();
            }

            Exit();
        }

        public void ChangeScene(SceneType scene)
        {
            curScene.Exit();
            curScene = scenes[(int)scene];
            curScene.Enter();
        }

        public void ReturnScene()
        {
            curScene.Exit();
            curScene = prevScene;
            curScene.Enter();
        }

        public void StartBattle(Monster monster)
        {
            prevScene = curScene;
            curScene.Exit();
            curScene = scenes[(int)SceneType.Battle];
            ((BattleScene)curScene).SetBattle(player, monster);
            curScene.Enter();
        }

        private void Start()
        {
            isRuning = true;

            scenes[(int)SceneType.Title] = new TitleScene(this);
            scenes[(int)SceneType.Select] = new SelectScene(this);
            scenes[(int)SceneType.Confirm] = new ConfirmScene(this);
            scenes[(int)SceneType.Intro] = new IntroScene(this);
            scenes[(int)SceneType.Street] = new StreetScene(this);
            scenes[(int)SceneType.Battle] = new BattleScene(this);
            scenes[(int)SceneType.Store] = new TitleScene(this);
            scenes[(int)SceneType.Amhurst] = new VillageScene(this);
            scenes[(int)SceneType.SouthPerry] = new TitleScene(this);
            scenes[(int)SceneType.LithHarbor] = new TitleScene(this);

            curScene = scenes[(int)SceneType.Title];
            curScene.Enter();
        }

        private void Render()
        {
            curScene.Render();
        }

        private void Input()
        {
            curScene.Input();
        }

        private void Update()
        {
            curScene.Update();
        }

        private void Exit()
        {
            curScene.Exit();
        }
    }
}
