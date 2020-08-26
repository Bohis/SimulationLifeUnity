using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour {
	/// <summary>
	///	ссылка на объект с характеристиками
	/// </summary>
	[SerializeField] Specifications Stat;

	/// <summary>
	/// Триггер разрешения движения
	/// </summary>
    private bool _enter = true;
	
	/// <summary>
	/// Пройденное расстояние
	/// </summary>
	private float _distance;
    
	/// <summary>
    ///  Move bot forward
    /// </summary>
    public void Move() {
        _distance = 0;

		///Проверка возможности движения
		if ( !_enter ) {
			///Штраф к нейронной сети
			Stat.Web.ValueCrit--;
			Stat.HP -= 10;
			return;
		}
		else {
			Stat.BotData.Move++;
			StartCoroutine ( MoveAnimation ( ) );
		}
    }

	/// <summary>
	/// Анимация в параллельных потокахы
	/// </summary>					 
	IEnumerator MoveAnimation () {
        if (_distance < Stat.Speed) {
            if (!_enter) {
                StopCoroutine( MoveAnimation() );
                yield return null;
            }
            else {
                _distance += Stat.Speed / 20f;
                transform.Translate( Stat.Speed / 20f, 0, 0 );

                yield return new WaitForSeconds( 0.01f );
                StartCoroutine( MoveAnimation() );
            }
        }
        else {
            StopCoroutine( MoveAnimation() );
        }
    }
	/// Проверка пересечения границы с другим объектом

	private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Bot" || collision.gameObject.tag == "Organic" )
			_enter = false;
    }

    private void OnTriggerExit(Collider collision) {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Bot" || collision.gameObject.tag == "Organic" )
			_enter = true;
    }
}