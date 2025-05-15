using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.Netcode;
using UnityEngine;

public class PlayerAppearance : NetworkBehaviour
{
        public Sprite[] availableSprites;
        public SpriteRenderer spriteRenderer;

        private NetworkVariable<int> spriteIndex = new NetworkVariable<int>();

        public override void OnNetworkSpawn()
        {
            if (IsOwner)
            {
                int chosenIndex = NetworkManager.Singleton.LocalClientId == 0 ? 0 : 1;
                SetSpriteServerRpc(chosenIndex);
                Vector2 spawnPos2D = new Vector2(-2, -2.5f);
                transform.position = new Vector3(spawnPos2D.x, spawnPos2D.y, 0f);
            }

            if(!IsOwner)
            {
                Vector2 spawnPos2D = new Vector2(2, -2.5f);
                transform.position = new Vector3(spawnPos2D.x, spawnPos2D.y, 0f);
            }

            spriteIndex.OnValueChanged += OnSpriteIndexChanged;
            ApplySprite(spriteIndex.Value);
        }

        private void OnSpriteIndexChanged(int oldValue, int newValue)
        {
            ApplySprite(newValue);
        }

        private void ApplySprite(int index)
        {
            spriteRenderer.sprite = availableSprites[index];
        }

        [ServerRpc]
        private void SetSpriteServerRpc(int index)
        {
            spriteIndex.Value = index;
        }
}
