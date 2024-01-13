using UnityEngine;
using Zenject;

public class CharacterInstaller : MonoInstaller
{
    [SerializeField] private CharacterMover _characterMover;
    [SerializeField] private CharacterJumper _characterJumper;
    [SerializeField] private GravityHandler _gravityHandler;
    [SerializeField] private CharacterConfig _config;
    
    public override void InstallBindings()
    {
        BindCharacter();
    }

    private void BindCharacter()
    {
        Container.BindInterfacesAndSelfTo<CharacterMover>().FromInstance(_characterMover).AsSingle();
        Container.BindInterfacesAndSelfTo<CharacterJumper>().FromInstance(_characterJumper).AsSingle();
        Container.BindInterfacesAndSelfTo<GravityHandler>().FromInstance(_gravityHandler).AsSingle();
        Container.Bind<CharacterConfig>().FromInstance(_config).AsSingle();
    }
}