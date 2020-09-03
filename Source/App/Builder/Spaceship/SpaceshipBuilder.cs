using System;

using Assets.Source.App.Controllers.Spaceship.Attack;
using Assets.Source.App.Controllers.Spaceship.Energy;
using Assets.Source.App.Controllers.Spaceship.Life;
using Assets.Source.App.Controllers.Spaceship.Movement;
using Assets.Source.App.Data.Spaceship;
using Assets.Source.App.Utils.Coroutines;
using Assets.Source.App.Utils.Interfaces.Builders;
using Assets.Source.Experimental;

using UnityEngine;

/// <summary>
/// Contém as classes responsáveis por construir as naves do jogo
/// </summary>
namespace Assets.Source.App.Builders.Spaceship {

  /// <summary>
  /// Classe base responsável por construir as naves do jogo
  /// </summary>
  public abstract class SpaceshipBuilder : AbstractBuilder<SpaceshipData>,
    IBuildable<AttackData>,
    IBuildable<EnergyData>,
    IBuildable<LifeData>,
    IBuildable<MovementData>,
    IBuildable<SpaceshipData> {

    #region Propriedades

    #region Auto-implementadas

    /// <summary>
    /// O controlador de ataque da nave.
    /// Usada em subclasses para evitar castings espalhados pelo código
    /// </summary>
    protected AttackController _attackController { get; private set; }

    /// <summary>
    /// O controlador de vida da nave.
    /// Usada em subclasses para evitar castings espalhados pelo código
    /// </summary>
    protected LifeController _lifeController { get; private set; }

    /// <summary>
    /// O controlador de energia da nave.
    /// Usada em subclasses para evitar castings espalhados pelo código
    /// </summary>
    protected EnergyController _energyController { get; private set; }

    /// <summary>
    /// O controlador de movimento da nave.
    /// Usada em subclasses para evitar castings espalhados pelo código
    /// </summary>
    protected MovementController _movementController { get; private set; }

    #endregion

    #region Outras

    /// <summary>
    /// Retorna o controlador de ataque da nave convertido para o tipo necessário na classe
    /// </summary>
    protected AttackController attackController => _attackController;

    /// <summary>
    /// Retorna o controlador de vida da nave convertido para o tipo necessário na classe
    /// </summary>
    protected LifeController lifeController => _lifeController;

    /// <summary>
    /// Retorna o controlador de energia da nave convertido para o tipo necessário na classe
    /// </summary>
    protected EnergyController energyController => _energyController;

    /// <summary>
    /// Retorna o controlador de movimento da nave convertido para o tipo necessário na classe
    /// </summary>
    protected MovementController movementController => _movementController;

    /// <summary>
    /// Retorna os dados da nave
    /// </summary>
    public override SpaceshipData data => SpaceshipData.values[objectToBuild.tag];

    #endregion

    #endregion

    #region Getters

    /// <summary>
    /// Retorna uma ação com os passos necessário para construir a nave
    /// </summary>
    /// 
    /// <returns>
    /// Uma ação com os passos necessário para construir a nave
    /// </returns>
    public override Action getActions () {
      return () => {
        onBuild(objectToBuild);
        onBuild(data.attackData);
        onBuild(data.energyData);
        onBuild(data.lifeData);
        onBuild(data.movementData);
        onBuild(data);
      };
    }

    #endregion

    #region Meus Métodos

    /// <summary>
    /// Inicializa os campos do builder
    /// </summary>
    /// 
    /// <param name="spaceship">
    /// A nave com os componentes que o builder precisa
    /// </param>
    public override void onBuild (GameObject spaceship) {
      _attackController = spaceship.GetComponent<AttackController>();
      _lifeController = spaceship.GetComponent<LifeController>();
      _movementController = spaceship.GetComponent<MovementController>();
      _energyController = spaceship.GetComponent<EnergyController>();
    }

    /// <summary>
    /// Inicializa o controlador de ataque da nave
    /// </summary>
    /// 
    /// <param name="attackData">
    /// Os dados de ataque da nave
    /// </param>
    public virtual void onBuild (AttackData attackData) {
      if (attackController.normalAttackCoroutine == null) {
        attackController.normalAttackCoroutine =
          attackController.gameObject.AddComponent<CoroutineController>()
        ;
      }
    }

    /// <summary>
    /// Inicializa o controlador de energia da nave
    /// </summary>
    /// 
    /// <param name="energyData">
    /// Os dados de energia da nave
    /// </param>
    public virtual void onBuild (EnergyData energyData) {
      if (energyController.attackController == null) {
        energyController.attackController = attackController;
        energyController.lifeController = lifeController;
        energyController.movementController = movementController;
      }
    }

    /// <summary>
    /// Inicializa o controlador de vida da nave
    /// </summary>
    /// 
    /// <param name="lifeData">
    /// Os dados de vida da nave
    /// </param>
    public virtual void onBuild (LifeData lifeData) {
      lifeController.dead = false;
      if (lifeController.shieldSphereCollider == null) {
        lifeController.lifeCoroutine =
          lifeController.gameObject.AddComponent<CoroutineController>()
        ;
        lifeController.hp = new FieldWithAction<float>();
        lifeController.shield = new FieldWithAction<float>();
        lifeController.maxShield = new FieldWithAction<float>();
        lifeController.shieldSphereCollider = lifeController.GetComponentInChildren<SphereCollider>();
        lifeController.shieldSphereRenderer = lifeController.shieldSphereCollider.GetComponent<Renderer>();
      }
      lifeController.hp.Value = lifeData.hp;
      lifeController.hp.onValueChange = lifeController.onHpValueChange;
    }

    public virtual void onBuild (MovementData movementData) {
      if (movementController.movementCoroutine == null) {
        movementController.movementCoroutine =
          movementController.gameObject.AddComponent<CoroutineController>()
        ;
      }
    }

    /// <summary>
    /// Inicializa campos que dependem uns dos outros
    /// </summary>
    /// 
    /// <param name="spaceshipData">
    /// Os dados da nave
    /// </param>
    public virtual void onBuild (SpaceshipData spaceshipData) {
      energyController.updateSpaceshipStatus();
      lifeController.shield.Value = lifeController.maxShield.Value;
      lifeController.shield.onValueChange = lifeController.onShieldValueChange;
      lifeController.lifeCoroutine.play(lifeController.regenerateShield());
      movementController.movementCoroutine.play(movementController.normalMovement());
    }

    #endregion

  }
}