//#define EXAMPLE_TYPE_CLASS
#define EXAMPLE_TYPE_METHOD
//#define EXAMPLE_TYPE_PROPERTY

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 클래스 / 메서드 / 프로퍼티

#endregion

public class Example_05 : MonoBehaviour
{
    private int m_nValue = 100;

    public void Awake()
    {
#if EXAMPLE_TYPE_CLASS
        var DerivedA = new CDerived("HellFire", this);
        var DerivedB = new CDerived(10, 3.14f, "Hello", this);

        // 0 0 Hellfire 100 출력
        DerivedA.ShowInfo(); // 부모 1번, 자식 1번
        
        // 10 3.14 Hello this
        DerivedB.ShowInfo(); // 깊은 복사된 부모 1번, 자식 1번


#elif EXAMPLE_TYPE_METHOD

        int nLhs = 10;
        int nRhs = 20;

        SwapByValue(nLhs, nRhs);
        Debug.LogFormat("Lhs: {0}, Rhs: {1}", nLhs, nRhs);

        SwapByReference(ref nLhs, ref nRhs);
        Debug.LogFormat("Lhs: {0}, Rhs: {1}", nLhs, nRhs);

        int nValueA;
        int nValueB;

        // out이니깐 초기화해줘야하는데
        // 나중에 할당하고 싶을 땐 out을 붙여서 넘기면 된다.
        this.InitValue(out nValueA, out nValueB);
        Debug.LogFormat("nValueA: {0}, nValueB: {1}", nValueA, nValueB);

        CBase oBase = new CLeaf();

        oBase.ShowInfo();

        int nSumValueA = this.GetSumValue(1, 2, 3, 4, 5, 1.0f, 2.0f, 3.0f, 4.0f);
        int nSumValueB = this.GetSumValue(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);

        Debug.LogFormat("SumValueA {0}, SumValueB {1}", nSumValueA, nSumValueB);
#else

#endif
    }

#if EXAMPLE_TYPE_CLASS
    /* 얕은 복사 / 깊은 복사
     * C# 클래스는 결국 참조 형식
     * 
     */

    // 기초 클래스
    class CBase
    {
        protected int m_nValue = 0;
        protected float m_fValue = 0.0f;

        // 생성자 / 대표 생성자
        public CBase(int nValue, float fValue)
        {
            m_nValue = nValue;
            m_fValue = fValue;
        }

        public void ShowInfo()
        {
            Debug.LogFormat("정수: {0}, 실수: {1}", m_nValue, m_fValue);
        }
    }

    class CDerived : CBase, System.ICloneable
    {
        private string m_oString = "";
        private Example_05 m_oExample = null;

        public CDerived(string a_oString, Example_05 a_oExample) : this(0, 0.0f, a_oString, a_oExample)
        {

        }

        public CDerived(int a_nValue, float a_fValue, string a_oString, Example_05 a_oExample) : base(a_nValue, a_fValue)
        {
            m_oString = a_oString;
            m_oExample = a_oExample;
        }

        // 객체 복사
        public object Clone()
        {
            var oDerived = new CDerived(m_nValue, m_fValue, m_oString, m_oExample);

            return oDerived;
        }

        public new void ShowInfo()
        {
            base.ShowInfo();

            Debug.LogFormat("문자열: {0}, 예제클래스: {1}", m_oString, m_oExample.m_nValue);
        }


    }

#elif EXAMPLE_TYPE_METHOD

    class CBase
    {
        public virtual void ShowInfo()
        {
            Debug.Log("Base 정보 출력");
        }
    }

    class CDerived : CBase
    {
        public override void ShowInfo()
        {
            base.ShowInfo();

            Debug.Log("Derived 정보 출력");
        }

    }

    class CLeaf : CDerived
    {
        public override void ShowInfo()
        {
            base.ShowInfo();

            Debug.Log("Leaf 정보 출력");
        }
    }

    private int GetSumValue(params object[] a_oParams)
    {
        int nSumValue = 0;
        float fSumValue = 0.0f;

        CBase oBase = new CDerived();
        // as / is
        // 형변환이 가능한지 검사 (업 캐스팅, 다운 캐스팅이 가능한지 아닌지 확인)
        CDerived oDerived = oBase as CDerived;

        if(oDerived != null)
        {
            Debug.Log("다운 캐스팅에 성공");
        }

        for(int i = 0; i < a_oParams.Length; ++i)
        {
            if(a_oParams[i] is int)
            {
                nSumValue += (int)a_oParams[i];
            }
            else
            {
                fSumValue += (float)a_oParams[i];
            }
        }

        return nSumValue;
    }

    private void InitValue(out int a_nValueA, out int a_nValueB)
    {
        a_nValueA = 10;
        a_nValueB = 20;
    }

    // call by value
    private void SwapByValue(int a_nLhs, int a_nRhs)
    {
        int nTemp = a_nLhs;
        a_nLhs = a_nRhs;
        a_nRhs = nTemp;
    }

    // call by reference
    private void SwapByReference(ref int a_nLhs, ref int a_nRhs)
    {
        int nTemp = a_nLhs;
        a_nLhs = a_nRhs;
        a_nRhs = nTemp;
    }

#else

#endif
}
