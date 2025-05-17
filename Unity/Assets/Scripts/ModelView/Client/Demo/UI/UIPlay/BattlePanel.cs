using System.Collections.Generic;
using DG.Tweening;
using ET.Client;
using ET.Client.Card;
using TMPro;
using UnityEngine;

namespace ET
{
    public class BattlePanel : MonoBehaviour
    {
        public TextMeshProUGUI roundText;

        public Transform leftRoot;
        public Transform rightRoot;

        public Transform[] leftPos;
        public Transform[] rightPos;

        public Transform leftImpactPos; //左撞击点
        public Transform rightImpactPos; //右撞击点

        public Transform leftFlyPos; //左飞点
        public Transform rightFlyPos; //右飞点

        private int round;
        private List<int> left;
        private List<int> right;
        private long mineId;
        private long targetId;

        private List<BattleCardBase> leftCards;
        private List<BattleCardBase> rightCards;
        private Coroutine coroutine;

        private bool init;
        private bool run;
        private int index;

        public ParticleSystem lefthitPs;
        public ParticleSystem righthitPs;

        public BattleCardBase cardPrefab;

        /// <summary>
        /// 生成单位
        /// </summary>
        public void Init(BattleRoundResult result)
        {
            leftCards = new();
            rightCards = new();
            this.fakeData = result.CardInfos;
            this.round = result.Round;
            this.left = result.left;
            this.mineId = result.leftId;
            this.right = result.right;
            this.targetId = result.rightId;
            roundText.text = $"Round{round}";
            for (int i = 0; i < left.Count; i++)
            {
                var value = left[i];
                if (value <= 0)
                {
                    continue;
                }

                var card = Instantiate(cardPrefab, this.leftRoot);
                card.Init(value);
                card.transform.localPosition = this.leftPos[i].localPosition;
                card.name = "pos" + i;
                leftCards.Add(card);
            }

            for (int i = 0; i < right.Count; i++)
            {
                var value = right[i];
                if (value <= 0)
                {
                    continue;
                }

                var card = Instantiate(cardPrefab, this.rightRoot);
                card.Init(value);
                card.transform.localPosition = this.rightPos[i].localPosition;
                card.name = "pos" + i;

                rightCards.Add(card);
            }

            // MakeFakeData();

            init = true;
            run = true;
            index = 0;
        }

        private void MakeFakeData()
        {
            //构造一个假数据

            fakeData = new();

            /////
            Dictionary<long, UnitCardInfo> unitCardInfos1 = new();
            UnitCardInfo unitCardInfo1 = new();
            unitCardInfo1.Info = new Dictionary<int, int>();
            unitCardInfo1.Info.Add(0, left[0]);

            UnitCardInfo rightUnitCardInfo1 = new();
            rightUnitCardInfo1.Info = new Dictionary<int, int>();
            rightUnitCardInfo1.Info.Add(2, right[0]);

            unitCardInfos1.Add(1001, unitCardInfo1);
            unitCardInfos1.Add(1002, rightUnitCardInfo1);

            CardInfos cardInfos = new();
            cardInfos.UnitCardInfos = unitCardInfos1;

            ///////////////////

            Dictionary<long, UnitCardInfo> unitCardInfos2 = new();
            UnitCardInfo unitCardInfo2 = new();
            unitCardInfo2.Info = new Dictionary<int, int>();
            unitCardInfo2.Info.Add(0, left[0]);

            UnitCardInfo rightUnitCardInfo2 = new();
            rightUnitCardInfo2.Info = new Dictionary<int, int>();
            rightUnitCardInfo2.Info.Add(1, right[1]);
            rightUnitCardInfo2.Info.Add(2, right[1]);

            unitCardInfos2.Add(1001, unitCardInfo2);
            unitCardInfos2.Add(1002, rightUnitCardInfo2);

            CardInfos cardInfo2 = new();
            cardInfo2.UnitCardInfos = unitCardInfos2;

            fakeData.Add(cardInfos);
            fakeData.Add(cardInfo2);
        }

        public bool Update1()
        {
            if (!this.init)
            {
                return false;
            }

            if (run)
            {
                if (index < fakeData.Count)
                {
                    run = false;
                    this.mainSequence.AppendInterval(1f);

                    var value = this.fakeData[index].UnitCardInfos;
                    if (value.Count != 0)
                    {
                        this.mainSequence = this.StartImpact(value[this.mineId], value[this.targetId]);
                        this.mainSequence.OnComplete(() =>
                        {
                            run = true;
                            index++;
                        });
                        mainSequence.Play();
                    }
                }
                else
                {
                    //结束 、、
                    this.init = false;

                    // manager.

                    Debug.LogError("本轮结束了");
                    return true;
                }
            }

            return false;
        }

        private List<CardInfos> fakeData;
        private Sequence mainSequence;

        // 开始一轮对撞
        private Sequence StartImpact(UnitCardInfo left, UnitCardInfo right)
        {
            Sequence startImpact = DOTween.Sequence();
            startImpact.AppendInterval(0.4f);
            startImpact.AppendCallback(() => { Debug.LogError("开始一局对撞"); });
            startImpact.Append(StartLeftImpact(left));
            startImpact.Join(StartRightImpact(right));
            startImpact.AppendInterval(1f);
            return startImpact;
        }

        private List<BattleResult> sortList = new()
        {
            BattleResult.Drown,
            BattleResult.Die,
            //BattleResult.None,
            BattleResult.Add
        };

        private Sequence StartLeftImpact(UnitCardInfo left)
        {
            Sequence impact = DOTween.Sequence();
            impact.AppendCallback(() => { Debug.LogError("开始对撞"); });

            var localposition = leftCards[0].transform.localPosition;
            impact.Append(leftCards[0].transform.DOLocalMove(leftImpactPos.localPosition, 1f));

            foreach (var sort in sortList)
            {
                var temp = left.Info;
                if (temp.ContainsKey((int) sort))
                {
                    var value = temp[(int) sort];
                    var type = sort;

                    switch (type)
                    {
                        // 无论召唤新的还是冲撞
                        case BattleResult.Drown:
                            //掉马桶淹死
                            var index = this.leftCards.FindIndex((x) => { return x.CardId == value; });

                            if (index >= 0)
                            {
                                impact.AppendCallback(() => { leftCards[index].PlayDrownPs(); });
                                impact.AppendInterval(0.5f);

                                impact.AppendCallback(() =>
                                {
                                    Destroy(leftCards[index].gameObject);
                                    leftCards.RemoveAt(index);
                                });
                            }

                            break;
                        case BattleResult.Add:

                            //先退回去
                            impact.Append(leftCards[0].transform.DOLocalMove(localposition, 1f));

                            impact.AppendCallback(() =>
                            {
                                // 生辰一个单位
                                var card = Instantiate(cardPrefab, this.leftRoot);
                                card.Init(value);
                                card.transform.localPosition = this.leftPos[5].localPosition;
                                card.name = "pos5";
                                leftCards.Add(card);
                            });

                            return impact;

                            break;
                        case BattleResult.Die:
                            //飞
                            impact.AppendCallback(() =>
                            {
                                this.lefthitPs.Play();
                                leftCards[0].PlayFlyPs();
                            });
                            impact.Append(leftCards[0].transform.DOLocalMove(this.leftFlyPos.localPosition, 1f));
                            impact.AppendCallback(() =>
                            {
                                Destroy(leftCards[0].gameObject);
                                leftCards.RemoveAt(0);
                            });

                            return impact;

                            break;
                    }
                }
            }

            impact.Append(leftCards[0].transform.DOLocalMove(localposition, 1f));

            return impact;
        }

        private Sequence StartRightImpact(UnitCardInfo right)
        {
            Sequence impact = DOTween.Sequence();

            var localposition = rightCards[0].transform.localPosition;
            impact.Append(this.rightCards[0].transform.DOLocalMove(this.rightImpactPos.localPosition, 1f));
            foreach (var sort in sortList)
            {
                var temp = right.Info;
                if (temp.ContainsKey((int) sort))
                {
                    var value = temp[(int) sort];
                    var type = sort;

                    switch (type)
                    {
                        //无论召唤新的还是冲撞
                        case BattleResult.None:
                            //退回去

                            break;
                        // 无论召唤新的还是冲撞
                        case BattleResult.Drown:
                            //掉马桶淹死
                            var index = this.rightCards.FindIndex((x) => { return x.CardId == value; });

                            if (index >= 0)
                            {
                                impact.AppendCallback(() => { rightCards[index].PlayDrownPs(); });
                                impact.AppendInterval(0.5f);

                                impact.AppendCallback(() =>
                                {
                                    Destroy(rightCards[index].gameObject);
                                    rightCards.RemoveAt(index);
                                });
                            }

                            break;
                        case BattleResult.Add:
                            //先退回去
                            impact.Append(rightCards[0].transform.DOLocalMove(localposition, 1f));

                            impact.AppendCallback(() =>
                            {
                                // 生辰一个单位
                                var card = Instantiate(cardPrefab, this.rightRoot);
                                card.Init(value);
                                card.transform.localPosition = this.rightPos[5].localPosition;
                                card.name = "pos5";
                                rightCards.Add(card);
                            });

                            return impact;

                            break;
                        case BattleResult.Die:
                            //飞
                            impact.AppendCallback(() =>
                            {
                                this.righthitPs.Play();
                                rightCards[0].PlayFlyPs();
                            });
                            impact.Append(rightCards[0].transform.DOLocalMove(this.rightFlyPos.localPosition, 1f));

                            impact.AppendCallback(() =>
                            {
                                Destroy(rightCards[0].gameObject);
                                rightCards.RemoveAt(0);
                            });
                            return impact;

                            break;
                    }
                }
            }

            impact.Append(rightCards[0].transform.DOLocalMove(localposition, 1f));

            return impact;
        }

        private void OnDisable()
        {
            this.init = false;
        }

        private void OnDestroy()
        {
            this.init = false;
        }
    }
}